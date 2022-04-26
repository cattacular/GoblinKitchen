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

    public bool flinging;
    private bool Accelerator;
    private float tempVelocityx;
    private float tempVelocityy;
    private float tempVelocityz;
    private float inversetempVelocityx;
    private float inversetempVelocityy;
    private float inversetempVelocityz;

    private float accelerationFactor;
    

    // Start is called before the first frame update
    void Start()
    {
        accelerationFactor = .03f;
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuousMovement>();
        Accelerator = false;
        flinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(climbingHand)
        {
            flinging = true;
            continuousMovement.enabled = false;
            Climb();
            Accelerator = true;
        }
        else if (Accelerator)
        {
            continuousMovement.enabled = true;
            if ((inversetempVelocityx > 0 && (tempVelocityx < 0)) || (inversetempVelocityx < 0 && (tempVelocityx > 0)) || (inversetempVelocityy > 0 && (tempVelocityy < inversetempVelocityy)) || (inversetempVelocityy < 0 && (tempVelocityy > inversetempVelocityy)) || (inversetempVelocityz > 0 && (tempVelocityz < 0)) || (inversetempVelocityz < 0 && (tempVelocityz > 0)) ){
                Accelerate();
            }else{
                Accelerator = false;
            }
        } else {
            continuousMovement.enabled = true;
            flinging = false;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        tempVelocityx = velocity.x;
        tempVelocityy = -velocity.y;
        tempVelocityz = velocity.z;

        inversetempVelocityx = -velocity.x;
        inversetempVelocityy = velocity.y;
        inversetempVelocityz = -velocity.z;

        //character.Move(new Vector3(0,-velocity.y * Time.fixedDeltaTime, 0)); This is just for climbing in the y direction
        //character.Move(transform.rotation * -velocity * Time.fixedDeltaTime); this is how the tutorial said to put in climbing
        character.Move(transform.rotation * new Vector3(tempVelocityx, tempVelocityy, tempVelocityz) * .01f); // Implemented it this way because having the diections reversed for left to right and forward and backwards is wierd
    
    }

    void Accelerate()
    {
        if (tempVelocityx * inversetempVelocityx >= 0){
            tempVelocityx = 0;
        }
        if (tempVelocityz * inversetempVelocityz >= 0){
            tempVelocityz = 0;
        }
        character.Move(transform.rotation * new Vector3(tempVelocityx, tempVelocityy*1.25f, tempVelocityz) * .025f);
        tempVelocityx = (inversetempVelocityx < 0) ?  tempVelocityx - accelerationFactor : tempVelocityx + accelerationFactor;
        tempVelocityy = (inversetempVelocityy < 0) ? tempVelocityy - accelerationFactor : tempVelocityy + accelerationFactor;
        tempVelocityz = (inversetempVelocityz < 0) ? tempVelocityz - accelerationFactor : tempVelocityz + accelerationFactor;
    }
}