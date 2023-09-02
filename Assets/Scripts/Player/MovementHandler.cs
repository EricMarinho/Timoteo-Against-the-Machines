using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class MovementHandler : MonoBehaviour
    {
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void MovePlayer(Vector3 movement, float speed)
        {
            rb.transform.position += movement * speed;
        }
    }
}