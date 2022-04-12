using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotChecker : MonoBehaviour
{
    private Ingredient[] recipe;
    private int[] test;

    private Recipe correctRecipe;
    private int ingredientCount = 0;
    public GameObject RecipeBook;
    private CookFood cookFood;
    
    // Start is called before the first frame update
    void Start()
    {
        cookFood = this.GetComponent<CookFood>();
        recipe = new Ingredient[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Ingredient>()){
            BuildRecipe(other.gameObject.GetComponentInParent<Ingredient>());
            other.gameObject.GetComponentInParent<Ingredient>().enabled = false;
            if(CheckRecipe()){
                Cook(correctRecipe);
            }
        }
        else{
            //other.gameObject.AddComponent<DestroyAfterTime>().selfDestructTime = 5;
        }
    
    }

    private void BuildRecipe(Ingredient ingredient)
    {
        //Debug.Log(ingredient);
        if(ingredientCount == 0){
            Debug.Log(ingredient.amount);
            recipe[ingredientCount] = ingredient;
            
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
                recipe[ingredientCount] = ingredient;
                ingredientCount++;
            }
        }
    }

    private bool CheckRecipe(){
        Recipe[] recipeList = RecipeBook.GetComponent<RecipeList>().list;
        for(int i = 0; i < recipeList.Length; i++){
            int correctIngredientCount = 0;
            for(int j = 0; j < recipeList[i].ingredients.Length; j++){
                for(int k = 0; k < recipe.Length; k++){
                    Ingredient tempIngredient = recipeList[i].ingredients[j];
                    if(recipe[k].title == tempIngredient.title && recipe[k].amount >= tempIngredient.amount){
                        correctIngredientCount++;
                    }
                    else{
                        break;
                    }
                }
            }
            if(correctIngredientCount == recipeList[i].ingredients.Length){
                correctRecipe = recipeList[i];
                return true;
            }
        }
        return false;
    }

    private void Cook(Recipe recipe){
        Debug.Log(recipe.name);
        cookFood.recipeName = recipe.name;
        cookFood.cookingLevelMats = recipe.cookingLevelMats;
        cookFood.cookingInterval = recipe.cookIntervalTime;
        cookFood.enabled = true;
        GetComponent<PotChecker>().enabled = false;
    }

    
}
