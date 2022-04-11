using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{
    public string title;

    public float amount;

    public Ingredient(string name, float amountNeeded)
    {
        title = name;
        amount = amountNeeded;
    }
}
