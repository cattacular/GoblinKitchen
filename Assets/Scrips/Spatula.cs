using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public bool foodAttached = false;
    private GameObject attachedFood;

    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Food>()){
            foodAttached = true;
            attachedFood = other.gameObject;
        }
        else if(other.gameObject.transform.parent.CompareTag("Plate") && foodAttached){
            attachedFood.layer = 0;
            attachedFood.transform.position = other.gameObject.GetComponent<Plate>().foodPos.position;
            attachedFood.transform.rotation = other.gameObject.GetComponent<Plate>().foodPos.rotation;
            foodAttached = false;
        }
    }
}
