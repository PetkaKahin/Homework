using System;

namespace MiniGame
{
    public class WinToAllColorDestroy : IConditionEndGame
    {
        private int _CountDestroyedBall = 0;
        public BallHeandler BallHeandler { get; private set; }

        public event Action<string> EventGameEnded;

        public void ChekEndWin()
        {
            if (_CountDestroyedBall >= BallHeandler.Balls.Count)
                EventGameEnded?.Invoke(IConditionEndGame.WinText);
        }

        public void SetBallHeandler(BallHeandler ballHeandler)
        {
            BallHeandler = ballHeandler;

            Ball.EventDestroyedAction -= DestroedBall;
            Ball.EventDestroyedAction += DestroedBall;
        }

        private void DestroedBall()
        {
            _CountDestroyedBall++;
        }
    }
}

