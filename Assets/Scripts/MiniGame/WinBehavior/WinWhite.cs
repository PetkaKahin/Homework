using UnityEngine;

namespace MiniGame
{
    public class WinWhite : IConditionsWin
    {
        public void ChekVictory()
        {
            if (DB.BallsDestroy.ContainsKey(BallType.White))
            {
                if (DB.WhiteCountBall == DB.BallsDestroy[BallType.White])
                {
                    IConditionsWin.EndGameAction?.Invoke("Победа");
                }
            }

            if (DB.BallsDestroy.ContainsKey(BallType.Green) || DB.BallsDestroy.ContainsKey(BallType.Red))
            {
                IConditionsWin.EndGameAction?.Invoke("Пражение");
            }
        }
    }
}
