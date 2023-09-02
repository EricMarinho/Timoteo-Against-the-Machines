using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Objects
{
    public class ObjectsSanityDamageHandler : MonoBehaviour
    {
        [SerializeField] private int timeToDamage;
        private int damageTimer;
        private float secondsTimer;

        private void Update()
        {
            secondsTimer += Time.deltaTime;
            if (secondsTimer >= 1)
            {
                secondsTimer = 0;
                damageTimer -= 1;
                if(damageTimer < 1) {
                    secondsTimer = 0;
                    damageTimer = timeToDamage;
                    PlayerController.Instance.LoseSanity();
                    enabled = false;
                }
            }
        }

    }
}