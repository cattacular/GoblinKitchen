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
        tempTag = other.gameObject.tag;
        other.gameObject.tag = "Cutting";
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.tag = tempTag;
    }
}
