using System;

namespace MiniGame
{
    public class WinToAllColorDestroy : IConditionEndGame
    {
        public BallHeandler BallHeandler { get; private set; }

        public event Action<string> EventGameEnded;

        public void ChekGameEnd()
        {
            if (BallHeandler.CountDestroyedBalls >= BallHeandler.Balls.Count)
                EventGameEnded?.Invoke(IConditionEndGame.WinText);
        }

        public void SetBallHeandler(BallHeandler ballHeandler)
        {
            BallHeandler = ballHeandler;
        }
    }
}

