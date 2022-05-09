using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlStack : XRSimpleInteractable
{
    public GameObject bowl;

    private InputDevice targetDevice;

    public void SpawnBowl() {
        Instantiate(bowl, interactorsSelecting[0].transform.position, interactorsSelecting[0].transform.rotation); 
    }
}
