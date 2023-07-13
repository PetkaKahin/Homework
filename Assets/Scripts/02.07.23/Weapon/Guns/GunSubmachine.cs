using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class GunSubmachine : BaseShootingWeapon
    {
        [SerializeField] [Range(0.1f, 2f)] private float _TimeBetweenMultipleShot;
        [SerializeField] [Range(1, 5)] private int _countShoting;

        public override void Shot()
        {
            if (IsCanShot)
                StartCoroutine(MultipleShot(_countShoting, TimeBetweenShoting));
        }

        protected override void ChekRecharge() { }

        private IEnumerator MultipleShot(int count, float delay)
        {
            StartShot();

            for (int i = 0; i < count; i++)
            {
                CreateBullet(transform);

                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(_TimeBetweenMultipleShot);

            EndShot();
        }
    }
}
