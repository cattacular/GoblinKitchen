using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotChecker : MonoBehaviour
{
    private List<Ingredient> recipe = new List<Ingredient>();
    private int[] test;

    private Recipe correctRecipe;
    private int ingredientCount = 0;
    public GameObject RecipeBook;
    private CookPot cookPot;
    private int foodAmount = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        cookPot = this.GetComponent<CookPot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Ingredient>() && !(other.gameObject.CompareTag("Used")) ){
            other.gameObject.tag = "Used";
            Ingredient ingredient = other.gameObject.GetComponentInParent<Ingredient>();
            Destroy(other.gameObject.GetComponentInParent<Ingredient>());
            BuildRecipe(ingredient);
            if(CheckRecipe()){
                Cook(correctRecipe);
            }
        }
        else if(other.gameObject.CompareTag("Bowl") && cookPot.isFinished == true)
        {
            other.gameObject.tag = "Food";
            other.gameObject.AddComponent<Food>().title = cookPot.recipeName;
            GameObject foodPos = other.gameObject.transform.Find("foodPosition").gameObject;
            foodPos.GetComponent<Renderer>().material = cookPot.potContents.GetComponent<Renderer>().material;
            foodPos.SetActive(true);
            foodAmount--;
            if(foodAmount > 0){
                cookPot.potContents.GetComponent<Transform>().position = cookPot.foodLevels[foodAmount-1].transform.position;
            }
            else{
                foodAmount = 3;
                cookPot.potContents = cookPot.water;
                cookPot.potContents.GetComponent<Transform>().position = cookPot.foodLevels[foodAmount-1].transform.position;
            }

        }
        else if(other.gameObject.GetComponent<Cuttable>() && !(other.gameObject.GetComponent<Ingredient>()))
        {
            other.gameObject.tag = "Used";
        }
    
    }

    private void BuildRecipe(Ingredient ingredient)
    {
        if(ingredientCount == 0){
            recipe.Add(ingredient);
            ingredientCount++;
        }
        else{
            bool hasIngredient = false;
            for(int i = 0; i < ingredientCount; i++){
                if(recipe[i].title == ingredient.title){
                    recipe[i].amount = recipe[i].amount + ingredient.amount;
                    hasIngredient = true;

                    break;
                }
            }
            if(!hasIngredient){
                recipe.Add(ingredient);
                ingredientCount++;
            }
        }
    }

    private bool CheckRecipe(){
        Recipe[] recipeList = RecipeBook.GetComponent<RecipeList>().list;
        for(int i = 0; i < recipeList.Length; i++){
            int correctIngredientCount = 0;
            for(int j = 0; j < recipeList[i].ingredients.Length; j++){
                for(int k = 0; k < recipe.Count; k++){
                    Ingredient tempIngredient = recipeList[i].ingredients[j];
                    if(recipe[k].title == tempIngredient.title && recipe[k].amount >= tempIngredient.amount){
                        correctIngredientCount++;
                        //Debug.Log("correct ingredient: " + recipe[k].title);
                    }
                }
            }
            if(correctIngredientCount == recipeList[i].ingredients.Length){
                correctRecipe = recipeList[i];
                return true;
            }
        }

        printRecipe();
        return false;
    }

    private void Cook(Recipe recipe){
        cookPot.recipeName = recipe.name;
        cookPot.cookingLevelMods = recipe.cookingLevelMods;
        cookPot.cookingInterval = recipe.cookIntervalTime;
        cookPot.enabled = true;
        deleteUsed();
        GetComponent<PotChecker>().enabled = false;
    }

    private void printRecipe()
    {
        for(int i = 0; i < recipe.Count; i++)
        {
            Debug.Log("Ingredient: " + recipe[i].title +"      Amount: " + recipe[i].amount);
        }
    }

    private void deleteUsed()
    {
        GameObject[] usedObjects = GameObject.FindGameObjectsWithTag("Used");
        foreach(GameObject usedObject in usedObjects)
        {
            Destroy(usedObject);
        }
    }

    
}
