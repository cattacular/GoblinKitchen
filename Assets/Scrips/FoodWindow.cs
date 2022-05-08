using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodWindow : MonoBehaviour
{
    public  GameObject[] foodSpots;
    public int timeBeforeFoodLeaves = 30;

    public GameObject OrderArea;

    private List<bool> spotTaken = new List<bool>();



    void Start()
    {
        for(int i = 0; i < foodSpots.Length; i++){
            spotTaken.Add(false);
        }
    }
   


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.GetComponent<Food>() && other.CompareTag("Food")){
            other.tag = "Untagged";
            int emptySpot = spotTaken.IndexOf(false);
            if(emptySpot >= 0){
               spotTaken[emptySpot] = true;
               SendToFoodSpot(other.gameObject, emptySpot);
               //CalculateMoney()
           }
        }
        else if(other.gameObject.GetComponentInChildren<Food>() && other.CompareTag("Plate")){
            other.tag = "Untagged";
            int emptySpot = spotTaken.IndexOf(false);
            if(emptySpot >= 0){
               spotTaken[emptySpot] = true;
               SendToFoodSpot(other.gameObject, emptySpot);
               //CalculateMoney()
           }
        }

    }

    void SendToFoodSpot(GameObject food, int foodSpot)
    {
        Destroy(food.GetComponent<XRGrabInteractable>());
        food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation; 
        food.transform.position = foodSpots[foodSpot].transform.position;
        food.transform.rotation = foodSpots[foodSpot].transform.rotation;
        
        StartCoroutine(MakeKinematic(food));
        //if(checkForOrder())
        //{
            //CalculateMoney()
        //}
        food.AddComponent<DestroyAfterTime>().selfDestructTime = timeBeforeFoodLeaves;
        StartCoroutine(FreeUpSpace(foodSpot));
    }

    IEnumerator MakeKinematic(GameObject food)
    {
        yield return new WaitForSeconds(4f);
        food.GetComponent<Rigidbody>().isKinematic = true;
    }

    IEnumerator FreeUpSpace(int foodSpot)
    {
        yield return new WaitForSeconds(timeBeforeFoodLeaves);
        spotTaken[foodSpot] = false;
    }

    private bool checkForOrder()
    {
        return false;
    }
}
