using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;

    public float cookIntervalTime;

    public Material[] cookingLevelMats;

    public Recipe(Ingredient[] ingredientsNeeded, float cookTime, Material[] cookingLevelMaterials)
    {
        ingredients = ingredientsNeeded;
        cookIntervalTime = cookTime;
        cookingLevelMats = cookingLevelMaterials;
    }
}
