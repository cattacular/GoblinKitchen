using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spatula : MonoBehaviour
{
    public bool foodAttached = false;
    private GameObject attachedFood;

    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        if(other.GetComponent<Food>() && foodAttached == false){
            foodAttached = true;
            attachedFood = other.gameObject;
        }
        else if(other.gameObject.CompareTag("Plate") && foodAttached){
            Debug.Log("PLAAAAAAAAAAAATE HIT AAAAAAAAAND FOOD ATTACTCHED");
            attachedFood.layer = 0;
            attachedFood.GetComponent<XRGrabInteractable>().enabled = false;
            attachedFood.GetComponent<Collider>().enabled = false;
            attachedFood.transform.position = other.gameObject.GetComponent<Plate>().foodPos.position;
            attachedFood.transform.rotation = other.gameObject.GetComponent<Plate>().foodPos.rotation;
            attachedFood.transform.parent = other.gameObject.transform;
            foodAttached = false;
        }
    }
}
