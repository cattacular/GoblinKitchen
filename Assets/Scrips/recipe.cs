using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recipe : MonoBehaviour
{

    public string recipeName;
    public GameObject[] ingredients;
    public float[] cookingTimes = {0f, 5f,10f,15f,20f};
    public string[] cookingLevelName = {"super early","early","on time","late","too late!"};
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
        if (cookCount < cookingTimes.Length){
            if (timer < cookingTimes[cookCount]){
                    timer += Time.deltaTime;
            } else {
                Debug.Log(cookingLevelName[cookCount]);
                cookCount += 1;
                timer += Time.deltaTime;
            }
        }
    }
}
