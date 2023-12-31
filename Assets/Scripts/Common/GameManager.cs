using Speed;
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
        [SerializeField] private GameSpeedController speedController;
        private bool wasPaused = false;
        private bool wasGameOver = false;
        private float currentTimeScale = 1f;

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
            if(!wasGameOver && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))) {
                wasPaused = !wasPaused;
                speedController.enabled = !wasPaused;
                currentTimeScale = Time.timeScale;
                Time.timeScale = wasPaused ? 0f : currentTimeScale;
                containerPause.SetActive(wasPaused);
            }
        }

        public void GameOver() {
            wasGameOver = true;
            speedController.enabled = false;
            Debug.Log("GAME OVER!!!");
            Time.timeScale = 0;
            gameOverObject.SetActive(true);
        }

        public void StartGame() {
            Debug.Log("Start Game!!!");
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void Menu() {
            SceneManager.LoadScene(0);
        }

        public void Credits() {
            SceneManager.LoadScene(2);
        }

        public void QuitGame() => Application.Quit();
    }
}