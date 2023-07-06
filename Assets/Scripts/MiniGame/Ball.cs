using System;
using UnityEngine;

namespace MiniGame
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] protected BallType Type;

        public static Action<BallType> DestroyAction;

        public void DestroyBall()
        {
            DestroyAction?.Invoke(Type);

            Destroy(gameObject);
        }
    }
}
