using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CollisionHandler : MonoBehaviour
    {
        private PlayerController playerControllerInstance;

        private void Awake()
        {
            playerControllerInstance = PlayerController.Instance;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Interactable"))
            {
                playerControllerInstance.SetCurrentInteractingObject(collision.gameObject);
                playerControllerInstance.EnablePlayerInteraction();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Interactable"))
            {
                playerControllerInstance.SetCurrentInteractingObject(null);
                playerControllerInstance.DisablePlayerInteraction();
            }
        }
    }
}
