using UnityEngine;

namespace MiniGame
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private BallHeandler _ballHeandler;
        [SerializeField] private Clicker _clicker;
        [SerializeField] private EndGameMenu _endGameMenu;

        private static IConditionEndGame _conditionEndGame; // статический для записи из другой сцены

        private void Awake()
        {
            _conditionEndGame.SetBallHeandler(_ballHeandler);
        }

        public void CheckGameEnded()
        {
            _conditionEndGame.ChekGameEnd();
        }

        public static void SetConditionWin(IConditionEndGame condition) // статический для записи из другой сцены
        {
            _conditionEndGame = condition;
        }

        private void GameEnded(string messageEndGame)
        {
            _endGameMenu.SetActiveMenu(messageEndGame);
        }

        private void OnEnable()
        {
            _clicker.EventDestroyed += CheckGameEnded;
            _conditionEndGame.EventGameEnded += GameEnded;
        }

        private void OnDisable()
        {
            _clicker.EventDestroyed -= CheckGameEnded;
            _conditionEndGame.EventGameEnded -= GameEnded;
        }
    }
}
