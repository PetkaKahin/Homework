using System;

namespace MiniGame
{
    public interface IConditionEndGame
    {
        const string WinText = "Победа";
        const string DefeatText = "Поражение";

        event Action<string> EventGameEnded;

        BallHeandler BallHeandler { get; }

        void ChekGameEnd();
        void SetBallHeandler(BallHeandler ballHeandler);
    }
}
