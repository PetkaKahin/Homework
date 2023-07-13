using TMPro;
using UnityEngine;

namespace MiniGame
{
    public class EndGameMenu : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] TMP_Text _text;

        public void SetActiveMenu(string massageEndGame)
        {
            _canvas.gameObject.SetActive(true);
            _text.text = massageEndGame;
        }
    }
}
