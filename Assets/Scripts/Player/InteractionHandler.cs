using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InteractionHandler : MonoBehaviour
    {
        private PlayerController playerControllerInstance;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                playerControllerInstance.currentInteractingObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
