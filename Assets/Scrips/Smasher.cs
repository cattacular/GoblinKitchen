using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Smashable>() && other.gameObject.CompareTag("Smashing")){
            other.gameObject.GetComponent<Collider>().enabled = false;
            Smashable original = other.gameObject.GetComponent<Smashable>();
            Instantiate(original.smashed, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
