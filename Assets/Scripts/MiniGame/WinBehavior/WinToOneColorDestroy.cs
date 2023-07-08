using System;

namespace MiniGame
{
    public class WinToOneColorDestroy : IConditionEndGame
    {
        private BallType? _ballTypeForWin = null;
        private BallType _destroyedBallType;

        private int _countBallType = 0;
        private int _countDestroyedBallType = 0;

        public event Action<string> EventGameEnded;

        public BallHeandler BallHeandler { get; private set; }

        public void ChekGameEnd()
        {
            SetDestroyBallType(BallHeandler.DestroedBallType);
            _countDestroyedBallType = BallHeandler.CountDestroyedBalls;

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
        }

        private void SetDestroyBallType(BallType ballType)
        {
            if (_ballTypeForWin == null)
            {
                _ballTypeForWin = ballType;
                _countBallType = BallHeandler.CountBallOfBallType(ballType);
            }

            _destroyedBallType = ballType;
        }
    }
}
