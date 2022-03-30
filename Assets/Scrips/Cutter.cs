using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Cuttable>()){
            this.gameObject.GetComponent<Collider>().isTrigger = false;
            other.gameObject.GetComponent<Collider>().enabled = false;
            Cuttable original = other.gameObject.GetComponent<Cuttable>();
            Instantiate(original.leftHalf, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Instantiate(original.rightHalf, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
            Invoke("makeCuttable", 5);
        }
    }

    void makeCuttable(){
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }
}
