using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFood : MonoBehaviour
{

    public GameObject potContents;

    public string recipeName;
    public float cookingInterval = 5f;
    public string[] cookingLevelName = {"super early","early","on time","late","too late!"};
    public bool isFinished;
    public Material[] cookingLevelMats;
    public GameObject[] foodLevels;
    public Material water;
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
            potContents.GetComponent<MeshRenderer>().material = cookingLevelMats[cookCount];
            Debug.Log(cookingLevelName[cookCount]);
            cookCount += 1;

            if(cookCount == 4)
            {
                isFinished = true;
                GetComponent<PotChecker>().enabled = true;
                //GetComponent<CookFood>().enabled = false;
                //GetComponent<recipe>().enabled = false;
            }
        }
        else
        {
            CancelInvoke();
            GetComponent<CookFood>().enabled = false;
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
