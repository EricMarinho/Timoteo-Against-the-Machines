using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common {
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField] private GameObject containerPause;
        [SerializeField] private GameObject gameOverObject;
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

        public void GameOver() {
            Debug.Log("GAME OVER!!!");
            Time.timeScale = 0;
            gameOverObject.SetActive(true);
        }

        public void StartGame() {
            Debug.Log("Start Game!!!");
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
