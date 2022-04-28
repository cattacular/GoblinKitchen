using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;

    public float cookIntervalTime;

    public GameObject[] cookingLevelMods;

    public Recipe(Ingredient[] ingredientsNeeded, float cookTime, GameObject[] cookingLevelModels)
    {
        ingredients = ingredientsNeeded;
        cookIntervalTime = cookTime;
        cookingLevelMods = cookingLevelModels;
    }
}
