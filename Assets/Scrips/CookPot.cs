using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPot : MonoBehaviour
{

    public GameObject potContents;

    public string recipeName;
    public float cookingInterval = 5f;
    public string[] cookingLevelName = {"super early","early","on time","late","too late!"};
    public bool isFinished;
    public GameObject[] cookingLevelMods;
    public GameObject[] foodLevels;
    public GameObject water;
    private int cookCount = 0;
    private GameObject oldModel;
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
            if(potContents.GetComponent<MeshRenderer>().enabled != false){
                potContents.GetComponent<MeshRenderer>().enabled = false;
            }
            else{
                Destroy(oldModel);
            }
            oldModel = Instantiate(cookingLevelMods[cookCount], potContents.transform.position, potContents.transform.rotation);
            oldModel.transform.localScale = potContents.transform.lossyScale;
            Debug.Log(cookingLevelName[cookCount]);
            cookCount += 1;

            if(cookCount == 4)
            {
                isFinished = true;
                GetComponent<PotChecker>().foodInPot = oldModel;
                GetComponent<PotChecker>().enabled = true;
                //GetComponent<CookFood>().enabled = false;
                //GetComponent<recipe>().enabled = false;
            }
        }
        else
        {
            CancelInvoke();
            GetComponent<CookPot>().enabled = false;
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
