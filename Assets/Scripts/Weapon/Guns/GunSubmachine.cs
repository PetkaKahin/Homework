using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class GunSubmachine : BaseShootingWeapon
    {
        [SerializeField] [Range(0.1f, 2f)] private float _TimeBetweenMultipleShot;
        [SerializeField] [Range(1, 5)] private int _countShoting;

        private bool _isMultipleShot = false;

        public override void Shot()
        {
            if (IsCanShot)
                StartCoroutine(MultipleShot(_countShoting, TimeBetweenShoting));

            IsCanShot = false;
        }

        protected override void ChekRecharge()
        {
            if (!_isMultipleShot)
            {
                if (Timer >= _TimeBetweenMultipleShot)
                {
                    IsCanShot = true;
                    ResetTimer();
                }
            }
        }

        private IEnumerator MultipleShot(int count, float delay)
        {
            _isMultipleShot = true;

            for (int i = 0; i < count; i++)
            {
                CreateBullet(transform);

                yield return new WaitForSeconds(delay);
            }

            _isMultipleShot = false;

            ResetTimer();
        }
    }
}
