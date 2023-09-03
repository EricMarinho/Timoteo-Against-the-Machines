using Audio;
using Objects;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interaction
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(ObjectsSanityDamageHandler))]
    [RequireComponent(typeof(InteractableActivationHandler))]
    public class InteractableHandler : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject necessaryItem = null;
        [SerializeField] private GameObject interactionButton;
        [SerializeField] private GameObject interaction;
        [SerializeField] private GameObject requiredObject = null;
        [SerializeField] private Transform pileToReturn;
        [SerializeField] private AudioClip activationSound;
        [SerializeField] private AudioClip deactivationSound;
        public bool isActive /*{ get; private set; }*/ = false; // Serialized for testing purpose
        private ObjectsSanityDamageHandler damageHandler;

        private void Start()
        {
            damageHandler = GetComponent<ObjectsSanityDamageHandler>();
        }

        public void Interact()
        {
            if (!isActive) return;

            if (requiredObject != null)
            {
                if (PlayerController.Instance.currentGrabbedObject == null) return;

                if (PlayerController.Instance.currentGrabbedObject != requiredObject)
                {
                    Debug.Log("Not the required object");
                    return;
                }
                requiredObject.transform.SetParent(pileToReturn, false);
                requiredObject.SetActive(false);
                PlayerController.Instance.SetCurrentGrabbedObject(null);
                Debug.Log("Released " + requiredObject.name);
            }

            AudioPlayerHandler.Instance.PlayDeactivateSound(deactivationSound);
            isActive = false;
            damageHandler.ResetSanityTimer();        
            
        }

        public void SetActive()
        {
            isActive = true;
            AudioPlayerHandler.Instance.PlayActivateSound(activationSound);
        }

        public void SetInactive()
        {
            isActive = false;
            interactionButton.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var player = collision.transform;
                var nameRequiredObject = requiredObject != null ? requiredObject.name : null;
                var child = nameRequiredObject != null ? player.Find(nameRequiredObject) : null;
                var nameChild = child != null ? child.name : null;
                var verificationSameGameObject = requiredObject != null ? nameRequiredObject == nameChild : false;
                if (isActive) {
                    if(requiredObject == null || verificationSameGameObject == true) {
                        interactionButton.SetActive(true);
                    } else {
                        necessaryItem.SetActive(true);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (isActive) {
                    interactionButton.SetActive(false);

                    if (necessaryItem != null) {
                        necessaryItem.SetActive(false);
                    }
                }
            }
        }
    }
}