using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipe : MonoBehaviour
{

    public string recipeName;
    public GameObject[] ingredients;
    public float[] doneTimes = {0f, 5f,10f,15f,20f};
    public string[] doneLevelName = {"raw","undercooked","done","burnt","blackened"};
    private int cookCount = 0;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //will 
        if (cookCount < doneTimes.Length){
            if (timer < doneTimes[cookCount]){
                    timer += Time.deltaTime;
            } else {
                Debug.Log(doneLevelName[cookCount]);
                Debug.Log(cookCount);
                cookCount += 1;
                timer += Time.deltaTime;
            }
        }
    }
}
