using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateStack : XRSimpleInteractable
{
    public GameObject plate;

    public void SpawnPlate(){
        Instantiate(plate, interactorsSelecting[0].transform.position, interactorsSelecting[0].transform.rotation);
    }
}
