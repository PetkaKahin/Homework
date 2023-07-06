using MiniGame;
using TMPro;
using UnityEngine;

public class WinSelection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        DB.SetConditionsWin(new WinAll());
    }

    public void PutWinSelection()
    {
        switch (_dropdown.value)
        {
            case 0:
                DB.SetConditionsWin(new WinAll());
                break;
            case 1:
                DB.SetConditionsWin(new WinRed());
                break;
            case 2:
                DB.SetConditionsWin(new WinGreen());
                break;
            case 3:
                DB.SetConditionsWin(new WinWhite());
                break;
        }
    }
}
