using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private ContinuousMovement continuousMovement;
    private bool Accelerator;

    private float tempVelocityx;
    private float tempVelocityy;
    private float tempVelocityz;
    private float accelerationFactor;
    

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuousMovement>();
        Accelerator = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand)
        {
            continuousMovement.enabled = false;
            Climb();
            Accelerator = true;
        }
        else if (Accelerator)
        {
            if (Math.Abs(tempVelocityx) > 0.05f || Math.Abs(tempVelocityy) > 0.05f || Math.Abs(tempVelocityz) > 0.05f ){
                Accelerate();
            }else{
                Accelerator = false;
            }
        } else {
            continuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        tempVelocityx = velocity.x;
        tempVelocityy = -velocity.y;
        tempVelocityz = velocity.z;

        //character.Move(new Vector3(0,-velocity.y * Time.fixedDeltaTime, 0)); This is just for climbing in the y direction
        //character.Move(transform.rotation * -velocity * Time.fixedDeltaTime); this is how the tutorial said to put in climbing
        character.Move(transform.rotation * new Vector3(tempVelocityx, tempVelocityy, tempVelocityz) * .01f); // Implemented it this way because having the diections reversed for left to right and forward and backwards is wierd
    
    }

    void Accelerate()
    {
        character.Move(transform.rotation * new Vector3(tempVelocityx, tempVelocityy, tempVelocityz) * .01f);
        tempVelocityx = (tempVelocityx > 0) ?  tempVelocityx - .05f : tempVelocityx + .05f;
        tempVelocityy = (tempVelocityy > 0) ? tempVelocityy - .05f : tempVelocityy + .05f;
        tempVelocityz = (tempVelocityz > 0) ? tempVelocityz - .05f : tempVelocityz + .05f;
    }
}
