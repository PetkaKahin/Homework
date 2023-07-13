using UnityEngine;

namespace Weapon
{
    public class Shooter : MonoBehaviour
    {
        private BaseShootingWeapon _weapon;

        private IClickMouseHandler _mouseHandler;

        private void Update()
        {
            if (_mouseHandler.MosueClick(IClickMouseHandler.LeftBatton))
                _weapon.Shot();
        }

        public void SetWeapon(BaseShootingWeapon weapon)
        {
            _weapon = weapon;

            switch (weapon)
            {
                case Gun:
                    _mouseHandler = new MouseDownHandler();
                    break;
                case GunMachine:
                    _mouseHandler = new MouseLongDonwHandler();
                    break;
                case GunSubmachine:
                    _mouseHandler = new MouseDownHandler();
                    break;
            }
        }
    }
}
