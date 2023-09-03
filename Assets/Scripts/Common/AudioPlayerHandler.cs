using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioPlayerHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource activationAudioSource;
        [SerializeField] private AudioSource deactivationAudioSource;
        [SerializeField] private AudioSource collectAudioSource;
        [SerializeField] private AudioSource loseSanityAudioSource;

        #region Singleton
        public static AudioPlayerHandler Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        #endregion

        public void PlayActivateSound(AudioClip audioClip)
        {
            activationAudioSource.PlayOneShot(audioClip);
        }

        public void PlayDeactivateSound(AudioClip audioClip)
        {
            deactivationAudioSource.PlayOneShot(audioClip);
        }

        public void PlayCollectSound(AudioClip audioClip)
        {
            collectAudioSource.PlayOneShot(audioClip);
        }

        public void PlayLoseSanitySound(AudioClip audioClip)
        {
            loseSanityAudioSource.PlayOneShot(audioClip);
        }

        public void StopActiveSound()
        {
            activationAudioSource.Stop();
        }

    }
}