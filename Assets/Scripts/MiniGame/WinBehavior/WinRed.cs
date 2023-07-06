using UnityEngine;

namespace MiniGame
{
    public class WinRed : IConditionsWin
    {
        public void ChekVictory()
        {
            if (DB.BallsDestroy.ContainsKey(BallType.Red))
            {
                if (DB.RedCountBall == DB.BallsDestroy[BallType.Red])
                {
                    IConditionsWin.EndGameAction?.Invoke("Победа");
                }
            }

            if (DB.BallsDestroy.ContainsKey(BallType.Green) || DB.BallsDestroy.ContainsKey(BallType.White))
            {
                IConditionsWin.EndGameAction?.Invoke("Пражение");
            }
        }
    }
}
