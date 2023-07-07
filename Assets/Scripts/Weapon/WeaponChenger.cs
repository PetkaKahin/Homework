using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class WeaponChenger : MonoBehaviour
    {
        [SerializeField] private List<BaseShootingWeapon> _weapons = new List<BaseShootingWeapon>();

        [SerializeField] private Shooter _shooter;

        [SerializeField] private int _weaponIndex = 0;

        private GameObject _currentWeapon;

        private void Start()
        {
            SwitchWeapon(_weaponIndex);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_weaponIndex + 1 < _weapons.Count)
                    _weaponIndex++;
                else
                    _weaponIndex = 0;

                SwitchWeapon(_weaponIndex);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_weaponIndex - 1 < 0)
                    _weaponIndex = _weapons.Count - 1;
                else
                    _weaponIndex--;

                SwitchWeapon(_weaponIndex);
            }
        }

        private void SwitchWeapon(int weaponIndex)
        {
            if (_currentWeapon != null)
                Destroy(_currentWeapon);

            _currentWeapon = Instantiate(_weapons[weaponIndex].gameObject, _shooter.transform);

            _shooter.SetWeapon(_currentWeapon.GetComponent<BaseShootingWeapon>()); 
        }
    }
}
