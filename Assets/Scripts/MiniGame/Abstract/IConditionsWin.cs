using System;

namespace MiniGame
{
    public interface IConditionsWin
    {
        static Action<string> EndGameAction { get; set; }

        void ChekVictory();
    }
}
