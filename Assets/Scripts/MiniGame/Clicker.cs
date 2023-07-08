using System;
using UnityEngine;

namespace MiniGame
{
    public class Clicker : MonoBehaviour
    {
        private const int ButtonMouseLeft = 0;

        public event Action<BallType> EventDestroyedReturnBallType;
        public event Action EventDestroyed;

        private void Update()
        {
            if (Input.GetMouseButtonDown(ButtonMouseLeft))
            {
                if (TryChekHitByBall(out Ball ball))
                {
                    EventDestroyedReturnBallType?.Invoke(ball.Type);
                    EventDestroyed?.Invoke();

                    ball.DestroyBall();

                    GameOver.ConditionEndGame.ChekGameEnd();
                }
            }
        }

        private bool TryChekHitByBall(out Ball ball)
        {
            Vector3 rayPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y));

            Ray ray = new Ray(rayPosition, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Ball ballToHit))
                {
                    ball = ballToHit;
                    return true;
                }
            }

            ball = null;
            return false;
        }
    }
}

