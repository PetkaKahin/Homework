using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class BallHeandler : MonoBehaviour
    {
        [field: SerializeField] public List<Ball> Balls { get; private set; } = new List<Ball>();

        public void CreateBall(BallType ballType, Transform parent) // типа будет использоваться в будущем, например при генерации шариков
        {
            Balls.Add(new Ball(ballType));

            Instantiate(Balls[Balls.Count], parent);
        }
    }
}
