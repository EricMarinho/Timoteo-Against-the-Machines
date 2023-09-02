using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common {
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField] private GameObject containerPause;
        private bool wasPaused = false;

        void Awake()
        {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                wasPaused = !wasPaused;
                Time.timeScale = wasPaused ? 0f : 1f;
                containerPause.SetActive(wasPaused);
            }
        }
    }

}
