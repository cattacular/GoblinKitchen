using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredient : MonoBehaviour
{

    public float[] heatTimes = { 0f, 1f, 2f, 3f, 4f };
    public string[] heatLevelName = { "raw", "undercooked", "just right", "burnt", "rock" };
    private int heatCount = 0;
    private float ztimer = 0f;



    //public float[] heatTimes = { 0f, 5f, 10f, 15f, 20f };
    //public string[] heatLevelName = { "raw", "undercooked", "just right", "burnt", "rock" };
    private bool isCooking = false;
    //private int heatCount = 0;
    //private float timer = 0f;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    void heatUpdate()
    {
        if (heatCount < heatLevelName.Length)
        {
            Debug.Log(heatLevelName[heatCount]);
            heatCount += 1;
        } else
        {
            CancelInvoke();
        }
            
    }

    // Update is called once per frame
    //void Update()
    //{

    //    //if (isCooking)
    //    //{
    //        if (heatCount < heatTimes.Length)
    //        {
    //            if (ztimer < heatTimes[heatCount])
    //            {
    //                ztimer += Time.deltaTime;
    //            }
    //            else
    //            {
    //                Debug.Log(heatLevelName[heatCount]);
    //                heatCount += 1;
    //                ztimer += Time.deltaTime;
    //            }
    //        }
    //    //}

       












        //if (isCooking)
        //{



        //if (heatCount < heatTimes.Length){
        //    if (timer < heatTimes[heatCount]){
        //        timer += Time.deltaTime;
        //    }else{
        //        Debug.Log(heatLevelName[heatCount]);
        //    Debug.Log(heatCount);
        //        heatCount += 1;
        //        timer += Time.deltaTime;
        //    }
        //}
        //}
    //}

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("heater"))
        {
            isCooking = true;
            InvokeRepeating("heatUpdate", 0f, 1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("heater"))
        {
            isCooking = false;
            CancelInvoke();
        }
    }
}
