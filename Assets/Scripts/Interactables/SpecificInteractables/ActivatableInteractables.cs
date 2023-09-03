using Audio;
using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ActivatableInteractables : MonoBehaviour
    {
        private InteractableHandler interactableHandler;
        private Animator animator;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (!interactableHandler.isActive)
            {
                animator.SetBool("isActive", false);
                return;
            }

            animator.SetBool("isActive", true);
        }
    }
}