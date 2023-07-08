using UnityEngine;

namespace Weapon
{
    public class MouseDownHandler : IClickMouseHandler
    {
        public bool MosueClick(int mouseButton)
        {
            if (Input.GetMouseButtonDown(mouseButton)) 
                return true;

            return false;
        }
    }
}
