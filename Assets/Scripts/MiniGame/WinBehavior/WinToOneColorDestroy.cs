using System;

namespace MiniGame
{
    public class WinToOneColorDestroy : IConditionEndGame
    {
        private BallType? _ballTypeForWin = null;
        private BallType? _destroyedBallType = null;

        private int _countBallType = 0;
        private int _countDestroyedBallType = 0;

        public event Action<string> EventGameEnded;

        public BallHeandler BallHeandler { get; private set; }

        public void ChekEndWin()
        {
            if (_destroyedBallType == _ballTypeForWin)
            {
                if (_countBallType == _countDestroyedBallType)
                {
                    EventGameEnded?.Invoke(IConditionEndGame.WinText);
                }

                return;
            }

            EventGameEnded?.Invoke(IConditionEndGame.DefeatText);
        }

        public void SetBallHeandler(BallHeandler ballHeandler)
        {
            BallHeandler = ballHeandler;

            OffSubcription();
            OnSubcription();
        }

        private void SetDestroedBall(Ball ball)
        {
            _destroyedBallType = ball.Type;
            _countDestroyedBallType++;
        }

        private void SetBallTypeForWin(Ball ball)
        {
            if (_ballTypeForWin == null)
                _ballTypeForWin = ball.Type;

            Ball.EventDestroyedActionReturnBall -= SetBallTypeForWin;

            for (int i = 0; i < BallHeandler.Balls.Count; i++)
                if (BallHeandler.Balls[i].Type == _ballTypeForWin)
                    _countBallType++;
        }

        private void OnSubcription()
        {
            Ball.EventDestroyedActionReturnBall += SetBallTypeForWin;
            Ball.EventDestroyedActionReturnBall += SetDestroedBall;
        }

        private void OffSubcription()
        {
            Ball.EventDestroyedActionReturnBall -= SetBallTypeForWin;
            Ball.EventDestroyedActionReturnBall -= SetDestroedBall;
        }
    }
}
