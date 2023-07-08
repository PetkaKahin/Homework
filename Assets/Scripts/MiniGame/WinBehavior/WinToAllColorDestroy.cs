using System;

namespace MiniGame
{
    public class WinToAllColorDestroy : IConditionEndGame
    {
        public BallHandler BallHandler { get; private set; }

        public event Action<string> EventGameEnded;

        public void ChekGameEnd()
        {
            if (BallHandler.CountDestroyBalls >= BallHandler.Balls.Count)
                EventGameEnded?.Invoke(IConditionEndGame.WinText);
        }

        public void SetBallHandler(BallHandler ballHeandler)
        {
            BallHandler = ballHeandler;
        }
    }
}

