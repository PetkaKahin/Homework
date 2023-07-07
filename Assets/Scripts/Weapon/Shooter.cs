using UnityEngine;

namespace Weapon
{
    public class Shooter : MonoBehaviour
    {
        private BaseShootingWeapon _weapon;

        private IClickMouseHeandler _mouseHeandler;

        private void Update()
        {
            if (_mouseHeandler.MosueClick(0))
                _weapon.Shot();
        }

        public void SetWeapon(BaseShootingWeapon weapon)
        {
            if (_weapon != null)
                Destroy(_weapon.gameObject);

            BaseShootingWeapon NewWeapon = Instantiate(weapon.gameObject, transform).GetComponent<BaseShootingWeapon>();

            switch (weapon)
            {
                case Gun:
                    _mouseHeandler = new MouseDownHeandler();
                    break;
                case GunMachine:
                    _mouseHeandler = new MouseLongDonwHeandler();
                    break;
                case GunSubmachine:
                    _mouseHeandler = new MouseDownHeandler();
                    break;
            }

            _weapon = NewWeapon;
        }
    }
}
