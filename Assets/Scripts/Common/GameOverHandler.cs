using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOver
{
    public class GameOverHandler : MonoBehaviour
    {
        private void Start()
        {
            Player.PlayerController.Instance.GameOverEvent += GameOver;
        }

        private void GameOver()
        {
            Debug.Log("GAME OVER!!!");
        }
    }
}
