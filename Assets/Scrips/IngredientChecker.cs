using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IngredientChecker : MonoBehaviour
{
    public int carrotCountTotal = 2;
    public int potatoCountTotal = 0;
    public int mushroomCountTotal = 1;
    public Material water;
    private int carrotCount = 0;
    private int potatoCount = 0;
    private int mushroomCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = water;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HasWon()
    {
        int itemsNeeded = carrotCountTotal + mushroomCountTotal + potatoCountTotal;
        int itemsHave = carrotCount + mushroomCount + potatoCount;
        if(itemsNeeded == itemsHave)
        {
            GetComponent<recipe>().enabled = true;
        }
    }

    private void hasUsed(Collider other) 
    {
        other.tag = "Used";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Carrot") && carrotCount != carrotCountTotal)
        {
            carrotCount++;
            hasUsed(other);
        }
        else if(other.gameObject.CompareTag("Potato") && potatoCount != potatoCountTotal)
        {
            potatoCount++;
            hasUsed(other);
        }
        else if(other.gameObject.CompareTag("Mushroom") && mushroomCount != mushroomCountTotal)
        {
            mushroomCount++;
            hasUsed(other);
        }
        HasWon();
    }

    
}
