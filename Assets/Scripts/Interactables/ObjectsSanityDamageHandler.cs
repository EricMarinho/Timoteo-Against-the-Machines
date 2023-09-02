using Interaction;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(InteractableHandler))]
    public class ObjectsSanityDamageHandler : MonoBehaviour
    {
        [SerializeField] private int timeToDamage;
        private int damageTimer;
        private float secondsTimer;

        private InteractableHandler interactableHandler;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            PlayerController.Instance.TookDamage += ResetSanityTimer;
            damageTimer = timeToDamage;
        }

        private void Update()
        {
            secondsTimer += Time.deltaTime;
            if (secondsTimer >= 1f)
            {
                secondsTimer = 0f;
                damageTimer -= 1;
                if(damageTimer <= 0) {
                    ResetSanityTimer();
                    PlayerController.Instance.LoseSanity();
                }
            }
        }

        public void ResetSanityTimer()
        {
            secondsTimer = 0f;
            damageTimer = timeToDamage;
            enabled = false;
            interactableHandler.SetInactive();
        }
    }
}