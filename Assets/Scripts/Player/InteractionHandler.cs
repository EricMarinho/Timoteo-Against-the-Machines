using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InteractionHandler : MonoBehaviour
    {
        private PlayerController playerControllerInstance;

        private void Start()
        {
            playerControllerInstance = PlayerController.Instance;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerControllerInstance.currentInteractingObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
