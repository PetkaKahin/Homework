using UnityEngine;

namespace Weapon
{
    public class MouseLongDonwHeandler : IClickMouseHeandler
    {
        public bool MosueClick(int mouseButton)
        {
            if (Input.GetMouseButton(mouseButton))
                return true;

            return false;
        }
    }
}
