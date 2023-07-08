using System;
using UnityEngine;

namespace MiniGame
{
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public BallType Type { get; private set; }
        public Ball(BallType type)
        {
            Type = type;
        }

        public void DestroyedBall()
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
