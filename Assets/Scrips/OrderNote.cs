using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderNote : MonoBehaviour
{
    public RecipeList recipeList;

    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public OrderAreaController orderAreaController;
    public int orderNumber = 0;
    public Recipe chosenRecipe;

    void Start()
    {
        if(recipeList == null){
            recipeList = FindObjectOfType<RecipeList>();
        }

        


        chosenRecipe = recipeList.list[Random.Range(0, recipeList.list.Length)];
        title.text = "Order #" + orderNumber;
        content.text = chosenRecipe.name;
        for(int i = 0; i < chosenRecipe.ingredients.Length; i++)
        {
            if(chosenRecipe.name == "Steak" || chosenRecipe.name == "Fried Egg"){
                content.text = content.text + "\n -" + chosenRecipe.ingredients[i].name + ": 1";
            }
            else{
                content.text = content.text + "\n -" + chosenRecipe.ingredients[i].name + ": " + chosenRecipe.ingredients[i].amount;
            }
            
        }
        FindObjectOfType<FoodWindow>().orders.Add(chosenRecipe.name);
    }
}
