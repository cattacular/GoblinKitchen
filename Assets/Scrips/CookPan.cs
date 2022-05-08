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
    public Transform cookedSpot;
    private int cookCount = 0;
    private float timer = 0f;
    private GameObject oldModel;
    // Start is called before the first frame update
    void OnEnable()
    {
        cookCount = 0;
        timer = 0f;
        if (cookCount < cookingLevelName.Length)
        {
            InvokeRepeating("timeUpdate", 0f, cookingInterval);
        }
    }

    void timeUpdate()
    {
        if (cookCount < cookingLevelName.Length)
        {
            GetComponent<PanChecker>().enabled = false;
            if(foodSpot.gameObject.activeSelf != false){
                foodSpot.gameObject.SetActive(false);
            }
            else{
                Destroy(oldModel);
            }
            oldModel = Instantiate(cookingLevelMods[cookCount], foodSpot.position, foodSpot.rotation);
            oldModel.transform.parent = transform.parent;
            oldModel.transform.localScale = foodSpot.localScale;
            Debug.Log(cookingLevelName[cookCount]);
            cookCount += 1;

            if(cookCount == 4)
            {
                //GetComponent<CookFood>().enabled = false;
                //GetComponent<recipe>().enabled = false;
            }
        }
        else
        {
            isFinished = true;
            GetComponent<PanChecker>().enabled = true;
            this.gameObject.transform.parent.position = cookedSpot.position;
            this.gameObject.transform.parent.rotation = cookedSpot.rotation;
            GetComponentInParent<XRGrabInteractable>().enabled = true;
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
