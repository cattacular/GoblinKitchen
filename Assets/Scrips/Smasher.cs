using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Smashable>() && other.gameObject.CompareTag("Smashing")){
            other.gameObject.GetComponent<Collider>().enabled = false;
            Smashable original = other.gameObject.GetComponent<Smashable>();
            GameObject temp = Instantiate(original.smashed, other.gameObject.transform.position, other.gameObject.transform.rotation);
            temp.transform.Rotate(new Vector3(-90,0,0), Space.Self);
            Destroy(other.gameObject);
        }
    }
}
