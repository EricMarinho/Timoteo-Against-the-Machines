using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hub {
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {   
        [SerializeField] private float maxHealth = 3f;
        [Header("Fill Configuration")]
        [SerializeField] private Image fill;
        [SerializeField] private Color fullHealth;
        [SerializeField] private Color middleHealth;
        [SerializeField] private Color lowHealth;
        private float health;
        private Slider slider;
        void Start()
        {
            health = maxHealth;
            slider = GetComponent<Slider>();
            slider.maxValue = maxHealth;
            slider.wholeNumbers = true;
            slider.value = health;
            fill.color = fullHealth;
        }

        void Update () {
            if(Input.GetKeyDown(KeyCode.Space)) {
                HeathDamage(1f);
            }
        }

        Color ChangeColor(float health) {
            var currentPercentage = (health*100) / maxHealth;
            return currentPercentage >= 66f ? fullHealth : currentPercentage >= 33f ? middleHealth : lowHealth;
        }

        public void HeathDamage(float damage) {
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            slider.value = health;
            fill.color = ChangeColor(health);
        }
    }
}
