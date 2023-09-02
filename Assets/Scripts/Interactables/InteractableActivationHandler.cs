using Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(InteractableHandler))]
    [RequireComponent(typeof(ObjectsSanityDamageHandler))]

    public class InteractableActivationHandler : MonoBehaviour
    {
        private InteractableHandler interactableHandler;
        private ObjectsSanityDamageHandler objectsSanityDamageHandler;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            objectsSanityDamageHandler = GetComponent<ObjectsSanityDamageHandler>();
        }

        public void ActivateObject()
        {
            interactableHandler.SetActive();
            objectsSanityDamageHandler.enabled = true;
        }

    }
}