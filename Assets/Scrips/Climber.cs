using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private ContinuousMovement continuousMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuousMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand)
        {
            continuousMovement.enabled = false;
            Climb();
        }
        else
        {
            continuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        //character.Move(new Vector3(0,-velocity.y * Time.fixedDeltaTime, 0)); This is just for climbing in the y direction
        //character.Move(transform.rotation * -velocity * Time.fixedDeltaTime); this is how the tutorial said to put in climbing
        character.Move(transform.rotation * new Vector3(velocity.x, -velocity.y, velocity.z) * Time.fixedDeltaTime); // Implemented it this way because having the diections reversed for left to right and forward and backwards is wierd
    }
}
