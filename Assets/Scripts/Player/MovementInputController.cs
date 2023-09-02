using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{

    public class MovementInputController : MonoBehaviour
    {

        private float _horizontal;
        private float _vertical;

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            PlayerController.Instance.MovePlayer(new Vector3(_horizontal, _vertical, 0));
        }

    }
}
