using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class GunSubmachine : BaseShootingWeapon
    {
        [SerializeField] [Range(1, 5)] private int _countShoting;

        private bool _isShoting = false;

        protected override void Shot()
        {
            if (Input.GetMouseButtonDown(0) && !_isShoting)
                StartCoroutine(MultipleShot(_countShoting, TimeBetweenShoting));
        }

        private IEnumerator MultipleShot(int count, float delay)
        {
            _isShoting = true;

            for (int i = 0; i < count; i++)
            {
                Instantiate(Bullet, transform);
                
                yield return new WaitForSeconds(delay);
            }

            _isShoting = false;
        }
    }
}
