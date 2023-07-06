using UnityEngine;

namespace MiniGame
{
    public class WinAll : IConditionsWin
    {
        public void ChekVictory()
        {
            if (DB.TotalCountBall == DB.CountDestroyBall)
            {
                IConditionsWin.EndGameAction?.Invoke("Победа");
            }
        }
    }
}

