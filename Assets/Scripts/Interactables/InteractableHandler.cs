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
            AudioPlayerHandler.Instance.PlayActivateSound(activationSound);
            isActive = true;
        }

        public void SetInactive()
        {
            isActive = false;
        }
    }
}