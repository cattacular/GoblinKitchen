using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour
{

    public Recipe[] list = {
        tomatoSoup,
        stew
    };
    public static Ingredient[] tomatoSoupIngredients =
    {
        new Ingredient("Curshed Tomato", 2),
        new Ingredient("Salt", 1),
        new Ingredient("Onion", 1)
    };

    public static Recipe tomatoSoup = new Recipe(tomatoSoupIngredients);

    public static Ingredient[] stewIngredients = 
    {
        new Ingredient("Carrot", 2.5f),
        new Ingredient("Salt", 1),
        new Ingredient("Onion", 2),
        new Ingredient("pepper", 1)
    };

    public static Recipe stew = new Recipe(stewIngredients);
}
