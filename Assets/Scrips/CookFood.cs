using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFood : MonoBehaviour
{

    public string recipeName;
    public float cookingInterval = 5f;
    public string[] cookingLevelName = {"super early","early","on time","late","too late!"};
    public static bool isFinished;
    public Material[] cookingLevelMats;
    private int cookCount = 0;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (cookCount < cookingLevelName.Length)
        {
            InvokeRepeating("timeUpdate", 0f, cookingInterval);
        }
    }

    void timeUpdate()
    {
        if (cookCount < cookingLevelName.Length)
        {
            GetComponent<MeshRenderer>().material = cookingLevelMats[cookCount];
            Debug.Log(cookingLevelName[cookCount]);
            cookCount += 1;

            if(cookCount == 4)
            {
                
                //GetComponent<recipe>().enabled = false;
            }
        }
        else
        {
            CancelInvoke();
        }

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    if (cookCount < cookingTimes.Length){
    //        if (timer < cookingTimes[cookCount]){
    //                timer += Time.deltaTime;
    //        } else {
    //            Debug.Log(cookingLevelName[cookCount]);
    //            cookCount += 1;
    //            timer += Time.deltaTime;
    //        }
    //    }
    //}
}