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
    
    public static string text;
    

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

    // void Climb()
    // {
    //     InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
    //     character.Move(transform.rotation * -velocity* Time.fixedDeltaTime);
    //     Debug.Log("x: " + velocity.x.ToString());
    //     Debug.Log("y: " + velocity.y.ToString());
    //     Debug.Log("z: " + velocity.z.ToString());
    // }

    void Climb()
    {
        Debug.Log(Time.fixedDeltaTime);
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        float xVelocity = velocity.x * Time.fixedDeltaTime;
        float yVelocity = velocity.y * Time.fixedDeltaTime;
        float zVelocity = velocity.z * Time.fixedDeltaTime;
        character.Move(new Vector3(xVelocity,-yVelocity, 0));
            
        // if (position.z < 0 && position.x > 0){
        //     character.Move(new Vector3(xVelocity,-yVelocity, zVelocity));
        // } else if (position.z > 0 && position.x < 0){
        //     character.Move(new Vector3(-xVelocity,-yVelocity, -zVelocity));
        // } else if (position.z > 0 && position.x > 0){
        //     character.Move(new Vector3(xVelocity,-yVelocity, -zVelocity));
        // } else if (position.z < 0 && position.x < 0){
        //     character.Move(new Vector3(-xVelocity,-yVelocity, zVelocity));
        // }
        
        Debug.Log("x: " + position.x.ToString());
        Debug.Log("y: " + position.y.ToString());
        Debug.Log("z: " + position.z.ToString());
        
    }
        
        
    //     // Debug.Log("x" + velocity.x.ToString());
    //     // Debug.Log("y" + velocity.y.ToString());
    //     // Debug.Log("z" + velocity.z.ToString());
    // }


}
