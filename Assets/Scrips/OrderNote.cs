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
    private int orderNumber;
    private Recipe chosenRecipe;

    void Start()
    {
        if(recipeList == null){
            recipeList = FindObjectOfType<RecipeList>();
        }

        orderNumber = orderAreaController.orderCount;

        chosenRecipe = recipeList.list[Random.Range(0, recipeList.list.Length)];
        title.text = "Order #" + orderNumber;
        content.text = chosenRecipe.name;
        for(int i = 0; i < chosenRecipe.ingredients.Length; i++)
        {
            content.text = content.text + "\n -" + chosenRecipe.ingredients[i].name + ": " + chosenRecipe.ingredients[i].amount;
        }
    }
}
