using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanChecker : MonoBehaviour
{
    public Recipe panRecipe;
    public GameObject[] bread;
    public int breadCount = 0;
    public GameObject cheese;
    public GameObject grilledCheese;
    public GameObject egg;
    public ParticleSystem goodIngredientEffect;
    public GameObject steak;
    public Transform foodPos;
    //[HideInInspector]
    public List<Ingredient> inPan = new List<Ingredient>();
    public bool readyToCook = false;

    void Start(){
        if(panRecipe != null){
            for(int i = 0; i < panRecipe.ingredients.Length; i++){
                inPan.Add(panRecipe.ingredients[i]);
            }
        }
        if(panRecipe != null){
            SetFoodPos();
        }

    }
    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.GetComponent<Ingredient>()){
            Debug.Log("testing");
            if(OnRecipe(other.gameObject.GetComponent<Ingredient>().title)){
                PlaceIngredient(other.gameObject);
                IsReady();
            }
            else{
                //play bad noise and particle effect with coroutine
            }
        }
        else if(other.gameObject.CompareTag("Oven") && readyToCook == true){
            GetComponent<CookPan>().foodSpot = foodPos;
            GetComponent<CookPan>().recipeName = panRecipe.name;
            GetComponent<CookPan>().cookingInterval = panRecipe.cookIntervalTime;
            GetComponent<CookPan>().cookingLevelMods = panRecipe.cookingLevelMods;
            GetComponent<CookPan>().enabled = true;
            readyToCook = false;
            this.gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
            GetComponentInParent<XRGrabInteractable>().enabled = false;
            this.gameObject.transform.parent.position = GetComponent<CookPan>().panLocation.position;
            

        }
    }

    private bool OnRecipe(string ingredientName){
        for(int i = 0; i < panRecipe.ingredients.Length; i++){
            Debug.Log(ingredientName + " == " + panRecipe.ingredients[i].name);
            if(ingredientName == panRecipe.ingredients[i].name){
                return true;
            }
        }
        return false;
    }

    void PlaceIngredient(GameObject ingredient)
    {
        string ingredientName = ingredient.GetComponent<Ingredient>().title;
        Destroy(ingredient);
        if(ingredientName == "Cheese"){
            cheese.SetActive(true);
            StartCoroutine("GoodEffect");
        }
        else if(ingredientName == "Bread Slice"){
            if(breadCount < 2){
                bread[breadCount].SetActive(true);
                StartCoroutine("GoodEffect");
            }
            breadCount++;
        }
        else if(ingredientName == "Egg"){
            egg.SetActive(true);
            StartCoroutine("GoodEffect");
        }
        else if(ingredientName == "Steak"){
            steak.SetActive(true);
            StartCoroutine("GoodEffect");
        }

        if(IsGrilledCheeseReady()){
            grilledCheese.SetActive(true);
        }
        for(int i = 0; i < inPan.Count; i++){
            if(inPan[i].name == ingredientName){
                inPan[i].amount++;
            }
        }

    }

    void IsReady(){
        int correctIngredients = 0;
        for(int i = 0; i < inPan.Count; i++){
            if(inPan[i].amount == panRecipe.ingredients[i].amount){
                correctIngredients++;
            }
        }
        if(correctIngredients == panRecipe.ingredients.Length){
            if(panRecipe.name == "Grilled Cheese"){
                bread[0].SetActive(false);
                bread[1].SetActive(false);
                cheese.SetActive(false);
            }
            readyToCook = true;
        }
    }


    private bool IsGrilledCheeseReady()
    {
        if(breadCount >= 2 && cheese.activeSelf){
            bread[0].SetActive(false);
            bread[1].SetActive(false);
            cheese.SetActive(false);
            breadCount = 0;
            return true;
        }
        return false;
    }

    private void SetFoodPos()
    {
        
        if(panRecipe.name == "Grilled Cheese"){
            foodPos = grilledCheese.transform;
        }
        else if(panRecipe.name == "Steak"){
            foodPos = steak.transform;
        }
        else{
            foodPos = egg.transform;
        }
    }

    private IEnumerator GoodEffect()
    {
        goodIngredientEffect.Play();
        yield return new WaitForSeconds(1);
        goodIngredientEffect.Stop();
    }

}
