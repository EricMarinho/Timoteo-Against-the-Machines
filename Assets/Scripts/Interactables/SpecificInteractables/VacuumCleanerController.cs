using Audio;
using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class VacuumCleanerController : MonoBehaviour
    {
        private InteractableHandler interactableHandler;
        private Animator animator;

        [SerializeField] private float turnTime;
        [SerializeField] private float moveSpeed;
        private float turnTimer = 0f;
        private float turnDirection = 1f;
        private bool isActive = false;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (!interactableHandler.isActive)
            {
                if (!isActive) return;
                
                isActive = false;
                AudioPlayerHandler.Instance.StopActiveSound();
                animator.SetBool("isActive", false);
                return;
                
            }

            isActive = true;
            animator.SetBool("isActive", true);
            turnTimer += Time.deltaTime;
            transform.position += new Vector3(moveSpeed * Time.deltaTime * turnDirection, 0f, 0f);

            if (turnTimer >= turnTime)
            {
                turnDirection *= -1;
                turnTimer = 0f;
            }
        }
    }
}
