using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanChecker : MonoBehaviour
{
    public Recipe panRecipe;
    public GameObject[] bread;
    public int breadCount = 0;
    public GameObject cheese;
    public GameObject grilledCheese;
    public GameObject egg;
    public GameObject steak;
    public Transform foodPos;
    //[HideInInspector]
    public List<Ingredient> inPan = new List<Ingredient>();
    public bool readyToCook = false;

    void Start(){

        for(int i = 0; i < panRecipe.ingredients.Length; i++){
            inPan.Add(panRecipe.ingredients[i]);
        }

        SetFoodPos();

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
            other.gameObject.GetComponent<CookPan>().foodSpot = foodPos;
            other.gameObject.GetComponent<CookPan>().recipeName = panRecipe.name;
            other.gameObject.GetComponent<CookPan>().cookingInterval = panRecipe.cookIntervalTime;
            other.gameObject.GetComponent<CookPan>().cookingLevelMods = panRecipe.cookingLevelMods;
            other.gameObject.GetComponent<CookPan>().enabled = true;
            readyToCook = false;
            this.gameObject.transform.parent.position = other.gameObject.GetComponent<CookPan>().panLocation.position;

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
        }
        else if(ingredientName == "Bread Slice"){
            if(breadCount < 2){
                bread[breadCount].SetActive(true);
            }
            breadCount++;
        }
        else if(ingredientName == "Egg"){
            egg.SetActive(true);
        }
        else if(ingredientName == "Steak"){
            steak.SetActive(true);
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
                DisableIngredients();

            }
            readyToCook = true;
        }
    }

    public void DisableIngredients(){
        Transform parent = foodPos.transform;
        foreach(Transform child in parent){
            if(child != parent){
                child.gameObject.SetActive(false);
            }
        }
        for(int i = 0; i < inPan.Count; i++){
            inPan[i].amount = 0;
        }
    }

    private bool IsGrilledCheeseReady(){
        if(breadCount >= 2 && cheese.activeSelf){
            bread[0].SetActive(false);
            bread[1].SetActive(false);
            cheese.SetActive(false);
            breadCount = 0;
            return true;
        }
        return false;
    }

    private void SetFoodPos(){
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

}
