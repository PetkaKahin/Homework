using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class BallHandler : MonoBehaviour
    {
        [SerializeField] private Clicker _cliker;
        [field: SerializeField] public List<Ball> Balls { get; private set; } = new List<Ball>();

        public int CountDestroyBalls { get; private set; } = 0;
        public BallType DestroedBallType { get; private set; }

        public void CreateBall(BallType ballType, Transform parent) // типа будет использоваться в будущем, например при генерации шариков
        {
            Balls.Add(new Ball());

            Balls[Balls.Count].Inicialize(ballType);

            Instantiate(Balls[Balls.Count], parent);
        }

        public int CountBallOfBallType(BallType ballType)
        {
            int count = 0;

            for (int i = 0; i < Balls.Count; i++)
            {
                if (ballType == Balls[i].Type)
                    count++;
            }

            return count;
        }

        private void AddDestroyBall(BallType ballType)
        {
            CountDestroyBalls++;
            DestroedBallType = ballType;
        }

        private void OnEnable()
        {
            _cliker.EventDestroyedReturnBallType += AddDestroyBall;
        }

        private void OnDisable()
        {
            _cliker.EventDestroyedReturnBallType -= AddDestroyBall;
        }
    }
}
