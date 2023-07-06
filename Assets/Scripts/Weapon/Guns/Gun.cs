using UnityEngine;

namespace Weapon
{
    public class Gun : BaseShootingWeapon
    {
        protected override void Shot()
        {
            if (Input.GetMouseButtonDown(0) && Timer >= TimeBetweenShoting)
            {
                Instantiate(Bullet, transform);
                ResetTimer();
            }
                
        }
    }
}
