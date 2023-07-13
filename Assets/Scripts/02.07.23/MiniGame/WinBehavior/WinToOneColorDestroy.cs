using System;

namespace MiniGame
{
    public class WinToOneColorDestroy : IConditionEndGame
    {
        private BallType? _ballTypeForWin = null;
        private BallType _destroyBallType;

        private int _countBallType = 0;
        private int _countDestroyBallType = 0;

        public event Action<string> EventGameEnded;

        public BallHandler BallHandler { get; private set; }

        public void ChekGameEnd()
        {
            SetDestroyBallType(BallHandler.DestroedBallType);
            _countDestroyBallType = BallHandler.CountDestroyBalls;

            if (_destroyBallType == _ballTypeForWin)
            {
                if (_countBallType == _countDestroyBallType)
                {
                    EventGameEnded?.Invoke(IConditionEndGame.WinText);
                }

                return;
            }

            EventGameEnded?.Invoke(IConditionEndGame.DefeatText);
        }

        public void SetBallHandler(BallHandler ballHeandler)
        {
            BallHandler = ballHeandler;
        }

        private void SetDestroyBallType(BallType ballType)
        {
            if (_ballTypeForWin == null)
            {
                _ballTypeForWin = ballType;
                _countBallType = BallHandler.CountBallOfBallType(ballType);
            }

            _destroyBallType = ballType;
        }
    }
}
