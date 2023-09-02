using Audio;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interaction
{
    public class CollectableHandler : MonoBehaviour, IInteractable
    {
        [SerializeField] private string collectableName;
        [SerializeField] private GameObject grabbedObject;
        [SerializeField] private Transform pileToReturn;
        [SerializeField] private AudioClip collectObjectAudioClip;
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
            AudioPlayerHandler.Instance.PlayCollectSound(collectObjectAudioClip);
            PlayerController.Instance.SetCurrentGrabbedObject(grabbedObject);
        }
    }
}