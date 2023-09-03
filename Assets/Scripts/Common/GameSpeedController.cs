using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Speed
{
    public class GameSpeedController : MonoBehaviour
    {
        [SerializeField] private StageData _stageData;
        [SerializeField] private AudioSource _audioSource;
        public float currentSpeedModifier { get; private set; } = 1;

        private void Start()
        {
            PlayerController.Instance.TookDamage += IncreaseSpeedByDamage;
        }

        private void Update()
        {
            currentSpeedModifier += _stageData.speedModifier * Time.deltaTime;
            Time.timeScale = currentSpeedModifier;
            _audioSource.pitch = currentSpeedModifier;
        }

        private void IncreaseSpeedByDamage()
        {
            currentSpeedModifier += _stageData.speedByDamageModifier;
            _audioSource.pitch += _stageData.speedByDamageModifier;
        }
    }
}