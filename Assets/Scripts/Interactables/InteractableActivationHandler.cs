using Objects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(InteractableHandler))]
    [RequireComponent(typeof(ObjectsSanityDamageHandler))]

    public class InteractableActivationHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        private InteractableHandler interactableHandler;
        private ObjectsSanityDamageHandler objectsSanityDamageHandler;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            objectsSanityDamageHandler = GetComponent<ObjectsSanityDamageHandler>();
        }

        public void ActivateObject()
        {
            timerText.transform.parent.gameObject.SetActive(true);
            interactableHandler.SetActive();
            objectsSanityDamageHandler.enabled = true;
            Debug.Log("Activated " + gameObject.name);
        }

    }
}