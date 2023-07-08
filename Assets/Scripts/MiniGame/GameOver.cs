using UnityEngine;

namespace MiniGame
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private BallHandler _ballHandler;
        [SerializeField] private Clicker _clicker;
        [SerializeField] private EndGameMenu _endGameMenu;

        public static IConditionEndGame ConditionEndGame { get; private set; } = new WinToAllColorDestroy(); // статический для записи из другой сцены

        private void Awake()
        {
            ConditionEndGame.SetBallHandler(_ballHandler);
        }

        public static void SetConditionWin(IConditionEndGame condition) // статический для записи из другой сцены
        {
            ConditionEndGame = condition;
        }

        private void GameEnd(string messageEndGame)
        {
            _endGameMenu.SetActiveMenu(messageEndGame);
        }

        private void OnEnable()
        {
            ConditionEndGame.EventGameEnded += GameEnd;
        }

        private void OnDisable()
        {
            ConditionEndGame.EventGameEnded -= GameEnd;
        }
    }
}
