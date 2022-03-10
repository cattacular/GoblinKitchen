using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int TomatoeCountTotal = 2;
    public int snailCountTotal = 0;
    public int onionCountTotal = 1;
    public Material water;
    private int TomatoeCount = 0;
    private int snailCount = 0;
    private int onionCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HasWon()
    {
        int itemsNeeded = TomatoeCountTotal + onionCountTotal + snailCountTotal;
        int itemsHave = TomatoeCount + onionCount + snailCount;
        if(itemsNeeded == itemsHave)
        {
            water.color = Color.magenta;
        }
    }

    private void hasUsed(Collider other) 
    {
        other.tag = "Used";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tomatoe") && TomatoeCount != TomatoeCountTotal)
        {
            TomatoeCount++;
            hasUsed(other);
        }
        else if(other.gameObject.CompareTag("Onion") && snailCount != snailCountTotal)
        {
            snailCount++;
            hasUsed(other);
        }
        else if(other.gameObject.CompareTag("Onion") && onionCount != onionCountTotal)
        {
            onionCount++;
            hasUsed(other);
        }
        HasWon();
    }

    
}
