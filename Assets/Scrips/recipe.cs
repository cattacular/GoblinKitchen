using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : Object
{
    public Ingredient[] ingredients;

    public Recipe(Ingredient[] ingredientsNeeded)
    {
        ingredients = ingredientsNeeded;
    }
}
