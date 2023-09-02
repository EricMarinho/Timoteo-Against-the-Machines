using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public float speed;
    }
}