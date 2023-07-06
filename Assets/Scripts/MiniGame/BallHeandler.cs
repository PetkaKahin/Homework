using UnityEngine;

namespace MiniGame
{
    public class BallHeandler : MonoBehaviour
    {
        [SerializeField] private DB _db;

        private void Start()
        {
            Ball.DestroyAction = DestroyBall;
        }

        private void DestroyBall(BallType ballType)
        {
            _db.AddDestroyBall(ballType);

            WinChecker.CheckWin(DB.ConditionsWin);
        }
    }
}
