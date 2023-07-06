using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class DB : MonoBehaviour
    {
        [SerializeField] private int _totalCountBall;
        [SerializeField] private int _redCountBall;
        [SerializeField] private int _greenCountBall;
        [SerializeField] private int _whiteCountBall;

        public static int CountDestroyBall { get; private set; }
        public static int TotalCountBall { get; private set; }
        public static int RedCountBall { get; private set; }
        public static int GreenCountBall { get; private set; }
        public static int WhiteCountBall { get; private set; }

        public static IConditionsWin ConditionsWin { get; private set; }
        public static Dictionary<BallType, int> BallsDestroy { get; private set; }

        private void Start()
        {
            CountDestroyBall = 0;
            RedCountBall = _redCountBall;
            GreenCountBall = _greenCountBall;
            WhiteCountBall = _whiteCountBall;
            TotalCountBall = _totalCountBall;

            BallsDestroy = new Dictionary<BallType, int>();
        }

        public static void SetConditionsWin(IConditionsWin conditionsVictory)
        {
            ConditionsWin = conditionsVictory;
        }

        public void AddDestroyBall(BallType ballType)
        {
            if (BallsDestroy.ContainsKey(ballType))
                BallsDestroy[ballType] += 1;
            else
                BallsDestroy.Add(ballType, 1);

            CountDestroyBall++;
        }
    }

    public enum BallType
    {
        Red,
        Green,
        White,
        All
    }
}
