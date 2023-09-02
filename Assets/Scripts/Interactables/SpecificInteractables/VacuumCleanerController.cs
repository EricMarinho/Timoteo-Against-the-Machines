using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class VacuumCleanerController : MonoBehaviour
    {
        private InteractableHandler interactableHandler;

        [SerializeField] private float turnTime;
        [SerializeField] private float moveSpeed;
        private float turnTimer = 0f;
        private float turnDirection = 1f;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
        }

        void Update()
        {
            if (!interactableHandler.isActive) return;

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
