using Audio;
using Interaction;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(InteractableHandler))]
    public class ObjectsSanityDamageHandler : MonoBehaviour
    {
        [SerializeField] private int timeToDamage;
        [SerializeField] private AudioClip loseSanityAudioClip;
        [SerializeField] private TMP_Text timerText;
        private int damageTimer;
        private float secondsTimer;

        private InteractableHandler interactableHandler;

        private void Start()
        {
            interactableHandler = GetComponent<InteractableHandler>();
            damageTimer = timeToDamage;
            PlayerController.Instance.TookDamage += ResetSanityTimer;
        }

        private void Update()
        {
            secondsTimer += Time.deltaTime;
            if (secondsTimer >= 1f)
            {
                timerText.SetText((damageTimer - 1).ToString());
                secondsTimer = 0f;
                damageTimer -= 1;
                if(damageTimer <= 0) {
                    ResetSanityTimer();
                    AudioPlayerHandler.Instance.PlayLoseSanitySound(loseSanityAudioClip);
                    PlayerController.Instance.LoseSanity();
                }
            }
        }

        public void ResetSanityTimer()
        {
            timerText.SetText(timeToDamage.ToString());
            timerText.transform.parent.gameObject.SetActive(false);
            secondsTimer = 0f;
            damageTimer = timeToDamage;
            enabled = false;
            interactableHandler.SetInactive();
        }
    }
}