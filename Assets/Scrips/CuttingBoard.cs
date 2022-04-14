using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public Transform leftCutPostion;
    public Transform rightCutPostion; 

    public string  tempTag = "Untagged";
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Cuttable>())
        {
            tempTag = other.gameObject.tag;
            other.gameObject.tag = "Cutting";
        }
        else if(other.gameObject.GetComponentInChildren<Smashable>())
        {
            tempTag = other.gameObject.tag;
            other.gameObject.tag = "Smashing";
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.tag = tempTag;
    }
}
