using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookPan : MonoBehaviour
{

    public Transform panLocation;
    public string recipeName;
    public float cookingInterval = 5f;
    public string[] cookingLevelName = {"super early","early","on time","late","too late!"};
    public bool isFinished;
    public GameObject[] cookingLevelMods;
    public Transform foodSpot;
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
            GetComponent<PanChecker>().DisableIngredients();
            GetComponent<PanChecker>().enabled = false;
            Instantiate(cookingLevelMods[cookCount], foodSpot.position, foodSpot.rotation);
            Debug.Log(cookingLevelName[cookCount]);
            cookCount += 1;

            if(cookCount == 4)
            {
                isFinished = true;
                GetComponent<PanChecker>().enabled = true;
                GetComponent<XRGrabInteractable>().enabled = true;
                //GetComponent<CookFood>().enabled = false;
                //GetComponent<recipe>().enabled = false;
            }
        }
        else
        {
            CancelInvoke();
            GetComponent<CookPan>().enabled = false;
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
