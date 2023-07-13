using UnityEngine;

namespace Weapon
{
    public class MouseLongDonwHandler : IClickMouseHandler
    {
        public bool MosueClick(int mouseButton)
        {
            if (Input.GetMouseButton(mouseButton))
                return true;

            return false;
        }
    }
}
