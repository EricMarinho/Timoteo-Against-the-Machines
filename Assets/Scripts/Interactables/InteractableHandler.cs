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
        [SerializeField] private GameObject requiredObject;
        [SerializeField] private Transform pileToReturn;
        public bool isActive /*{ get; private set; }*/ = false; // Serialized for testing purpose
        private ObjectsSanityDamageHandler damageHandler;

        private void Start()
        {
            damageHandler = GetComponent<ObjectsSanityDamageHandler>();
        }

        public void Interact()
        {
            if (PlayerController.Instance.currentGrabbedObject == null || !isActive) return;

            if(PlayerController.Instance.currentGrabbedObject != requiredObject) { 
                Debug.Log("Not the required object");
                return;
            }

            Debug.Log("Released " + requiredObject.name);
            isActive = false;
            damageHandler.ResetSanityTimer();
            requiredObject.transform.SetParent(pileToReturn, false);
            PlayerController.Instance.SetCurrentGrabbedObject(null);
            requiredObject.SetActive(false);
        }

        public void SetActive()
        {
            isActive = true;
        }

        public void SetInactive()
        {
            isActive = false;
        }
    }
}