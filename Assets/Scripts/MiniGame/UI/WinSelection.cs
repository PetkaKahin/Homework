using TMPro;
using UnityEngine;

namespace MiniGame
{
    public class WinSelection : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;

        private void Start()
        {
            GameOver.SetConditionWin(new WinToAllColorDestroy());
        }

        public void PutWinSelection()
        {
            switch (_dropdown.value)
            {
                case 0:
                    print("0");
                    GameOver.SetConditionWin(new WinToAllColorDestroy());
                    break;
                case 1:
                    print("1");
                    GameOver.SetConditionWin(new WinToOneColorDestroy());
                    break;
            }
        }
    }
}

