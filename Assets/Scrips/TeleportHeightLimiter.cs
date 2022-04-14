using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.Interaction.Toolkit
{
    public class TeleportHeightLimiter : BaseTeleportationInteractable
    {
        private CharacterController playerheight;
        /// <inheritdoc />
        protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            if (raycastHit.collider == null || (playerheight.transform.position.y < gameObject.transform.position.y)){
                return false;
            }
                

            teleportRequest.destinationPosition = raycastHit.point;
            teleportRequest.destinationRotation = transform.rotation;
            return true;
        }
    }
}

