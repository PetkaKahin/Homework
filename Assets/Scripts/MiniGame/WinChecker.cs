using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MiniGame
{
    public class WinChecker : MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            IConditionsWin.EndGameAction += EndGame;
        }

        public static void CheckWin(IConditionsWin conditionsWin)
        {
            conditionsWin.ChekVictory();
        }

        public void EndGame(string text)
        {
            _canvas.SetActive(true);
            _text.text = text;
        }
    }
}
