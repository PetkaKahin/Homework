using UnityEngine;

namespace Weapon
{
    public class GunMachine : BaseShootingWeapon
    {
        protected override void Shot()
        {
            if (Timer >= TimeBetweenShoting && Input.GetMouseButton(0))
            {
                Instantiate(Bullet, transform);
                ResetTimer();
            }
        }
    }
}
