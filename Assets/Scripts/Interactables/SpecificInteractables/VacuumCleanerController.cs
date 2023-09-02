using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class VacuumCleanerController : MonoBehaviour
    {
        [SerializeField] private float turnTime;
        [SerializeField] private float moveSpeed;
        private float turnTimer = 0f;
        private float turnDirection = 1f;

        void Update()
        {
            turnTimer += Time.deltaTime;
            transform.position += new Vector3(moveSpeed * Time.deltaTime * turnDirection, 0f, 0f);

            if (turnTimer >= turnTime)
            {
                turnTimer = 0f;
            }
        }
    }
}
