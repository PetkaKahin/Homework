using UnityEngine;

namespace MiniGame
{
    public class WinGreen : IConditionsWin
    {
        public void ChekVictory()
        {
            if (DB.BallsDestroy.ContainsKey(BallType.Green))
            {
                if (DB.GreenCountBall == DB.BallsDestroy[BallType.Green])
                {
                    IConditionsWin.EndGameAction?.Invoke("Победа");
                }
            }

            if (DB.BallsDestroy.ContainsKey(BallType.White) || DB.BallsDestroy.ContainsKey(BallType.Red))
            {
                IConditionsWin.EndGameAction?.Invoke("Пражение");
            }
        }
    }
}
