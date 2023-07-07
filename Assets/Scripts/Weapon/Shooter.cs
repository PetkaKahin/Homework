using System;
using UnityEngine;

namespace Weapon
{
    public class Shooter : MonoBehaviour
    {
        private BaseShootingWeapon _weapon;

        private Action _clickedMouseAction;

        private void Update()
        {
            _clickedMouseAction?.Invoke();
        }

        public void SetWeapon(BaseShootingWeapon weapon)
        {
            switch (weapon)
            {
                case Gun:
                    _clickedMouseAction = ShotOnMouseDown;
                    break;
                case GunMachine:
                    _clickedMouseAction = ShotingOnMouseDown;
                    break;
                case GunSubmachine:
                    _clickedMouseAction = ShotOnMouseDown;
                    break;
            }

            _weapon = weapon;
        }

        private void ShotOnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
                _weapon.Shot();
        }

        private void ShotingOnMouseDown()
        {
            if (Input.GetMouseButton(0))
                _weapon.Shot();
        }

        private void OnDestroy()
        {
            _clickedMouseAction = null;
        }
    }
}
