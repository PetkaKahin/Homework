using System;

namespace MiniGame
{
    public interface IConditionEndGame
    {
        const string WinText = "Победа";
        const string DefeatText = "Поражение";

        event Action<string> EventGameEnded;

        BallHandler BallHandler { get; }

        void ChekGameEnd();
        void SetBallHandler(BallHandler ballHeandler);
    }
}
