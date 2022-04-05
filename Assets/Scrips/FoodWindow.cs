using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWindow : MonoBehaviour
{
    public  GameObject[] foodSpots;
    public int timeBeforeFoodLeaves = 30;

    private List<bool> spotTaken;



    void Start()
    {
        for(int i = 0; i < foodSpots.Length; i++){
            spotTaken.Add(false);
        }
    }
   


    void onTiggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Food>()){
           int emptySpot = spotTaken.BinarySearch(false);
           if(emptySpot >= 0){
               spotTaken[emptySpot] = true;
               SendToFoodSpot(other.gameObject, emptySpot);
               //CalculateMoney()
           }
        }

    }

    void SendToFoodSpot(GameObject food, int foodSpot){
        food.transform.position = foodSpots[foodSpot].transform.position;
        food.transform.rotation = foodSpots[foodSpot].transform.rotation;
        food.GetComponent<Rigidbody>().isKinematic = true;
        food.gameObject.layer = 0;
        food.GetComponent<Food>().onWindow(timeBeforeFoodLeaves);
    }
}
