using UnityEngine;

namespace Weapon
{
    public class MouseDownHeandler : IClickMouseHeandler
    {
        public bool MosueClick(int mouseButton)
        {
            if (Input.GetMouseButtonDown(mouseButton)) 
                return true;

            return false;
        }
    }
}
