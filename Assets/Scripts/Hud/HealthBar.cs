using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Hub {
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {   
        public static HealthBar instance;
        [SerializeField] private PlayerData _data;
        private float maxHealth = 3f;
        [Header("Fill Configuration")]
        [SerializeField] private Image fill;
        [SerializeField] private Color fullHealth;
        [SerializeField] private Color middleHealth;
        [SerializeField] private Color lowHealth;
        [Header("Brain Configuration")]
        [SerializeField] private Image brain;
        [SerializeField] private Sprite fullBrain;
        [SerializeField] private Sprite middleBrain;
        [SerializeField] private Sprite lowBrain;
        [Header("Effect Camera Shake Configuration")]
        [SerializeField] private float shakeDuration = 0.5f;
	    [SerializeField] private float shakeIntensity = 0.1f;
        private float currentShakeDuration = 0f;
        private Camera mainCamera;
        private Vector3 originalPosition;
        private float health;
        private Slider slider;

        void Awake()
        {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            maxHealth = _data.maxSanity;
            Debug.Log(_data.maxSanity);
            health = maxHealth;
            slider = GetComponent<Slider>();
            slider.maxValue = maxHealth;
            slider.wholeNumbers = true;
            slider.value = health;
            fill.color = fullHealth;
            brain.sprite = fullBrain;
            mainCamera = Camera.main;
            originalPosition = mainCamera.transform.localPosition;
        }

        void Update() {
            if (currentShakeDuration > 0)
            {
                Debug.Log("Shake");
                mainCamera.transform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
                currentShakeDuration -= Time.deltaTime;
            }
            else
            {
                currentShakeDuration = 0f;
                mainCamera.transform.localPosition = originalPosition;
            }
        }
        void Shake()
        {
            currentShakeDuration = shakeDuration;
        }

        public void StopShake()
        {
            currentShakeDuration = 0f;
        }

        Color ChangeColor(float health) {
            var currentPercentage = (health*100) / maxHealth;
            return currentPercentage >= 70f ? fullHealth : currentPercentage >= 66f ? middleHealth : lowHealth;
        }

        Sprite ChangeSpriteBrain(float health) {
            var currentPercentage = (health*100) / maxHealth;
            return currentPercentage >= 70f ? fullBrain : currentPercentage >= 40f ? middleBrain : lowBrain;
        }

        public void SanityDamage(float damage) {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            slider.value = health;
            fill.color = ChangeColor(health);
            brain.sprite = ChangeSpriteBrain(health);
            Shake();
        }
    }
}
