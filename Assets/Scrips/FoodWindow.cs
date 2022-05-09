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
    public int correctFood = 0;
    public bool foodComplete = false;
    public List<string> orders = new List<string>();



    void Start()
    {
        for(int i = 0; i < foodSpots.Length; i++){
            spotTaken.Add(false);
        }
    }
   


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.GetComponent<Food>() && other.CompareTag("Food") && CheckForOrder(other.gameObject.GetComponentInChildren<Food>())){
            other.tag = "Untagged";
            int emptySpot = spotTaken.IndexOf(false);
            if(emptySpot >= 0){
               spotTaken[emptySpot] = true;
               SendToFoodSpot(other.gameObject, emptySpot);
               //CalculateMoney()
           }
        }
        else if(other.gameObject.GetComponentInChildren<Food>() && other.CompareTag("Plate") && CheckForOrder(other.gameObject.GetComponentInChildren<Food>())){
            other.tag = "Untagged";
            int emptySpot = spotTaken.IndexOf(false);
            if(emptySpot >= 0){
               spotTaken[emptySpot] = true;
               SendToFoodSpot(other.gameObject, emptySpot);
               if(foodComplete){
                   GetComponent<FoodWindow>().enabled = false;
               }
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
    }

    IEnumerator MakeKinematic(GameObject food)
    {
        yield return new WaitForSeconds(4f);
        food.GetComponent<Rigidbody>().isKinematic = true;
    }

    private bool CheckForOrder(Food food)
    {
        Debug.Log(food.title);
        if(orders.Contains(food.title)){
            
            correctFood++;
            if(correctFood > FindObjectOfType<OrderAreaController>().numOfOrders - 1){
                foodComplete = true;
                return true;
            }
            else{
                orders.Remove(food.title);
                return true;
            }
        }
        Debug.Log(false);
        return false;
    }
}
