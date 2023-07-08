using System;
using UnityEngine;

namespace MiniGame
{
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public BallType Type { get; private set; }

        public void Inicialize(BallType type)
        {
            Type = type;
        }

        public void DestroyBall()
        {
            Destroy(gameObject);
        }
    }

    public enum BallType
    {
        Red,
        Green,
        White,
    }
}
