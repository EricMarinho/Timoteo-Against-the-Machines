using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interaction
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollectableHandler : MonoBehaviour, IInteractable
    {
        [SerializeField] private string collectableName;
        [SerializeField] private GameObject grabbedObject;
        [SerializeField] private Transform pileToReturn;
        private PlayerController playerControllerInstance;

        private void Start()
        {
            playerControllerInstance = PlayerController.Instance;
        }

        public void Interact()
        {
            Debug.Log("Collected " + collectableName);
            if(playerControllerInstance.currentGrabbedObject != null && playerControllerInstance.currentGrabbedObject != grabbedObject)
            {
                Debug.Log("Swaped to a Different Object");
                playerControllerInstance.currentGrabbedObject.transform.SetParent(pileToReturn, false);
                playerControllerInstance.currentGrabbedObject.SetActive(false);
            }
            grabbedObject.transform.SetParent(PlayerController.Instance.transform, false);
            grabbedObject.SetActive(true);
            PlayerController.Instance.SetCurrentGrabbedObject(grabbedObject);
        }
    }
}