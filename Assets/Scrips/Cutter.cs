using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public CuttingBoard cuttingBoard;
    public Vector3 offSet = new Vector3(0,0,0.4f);
    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Cuttable>() && other.gameObject.CompareTag("Cutting")){
            
            other.gameObject.GetComponent<Collider>().enabled = false;
            Cuttable original = other.gameObject.GetComponent<Cuttable>();
            Instantiate(original.leftHalf, cuttingBoard.leftCutPostion.position, cuttingBoard.leftCutPostion.localRotation);
            Instantiate(original.rightHalf, cuttingBoard.rightCutPostion.position, cuttingBoard.rightCutPostion.localRotation);
            Destroy(other.gameObject);
        }
    }
}
