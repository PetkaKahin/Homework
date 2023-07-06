using UnityEngine;

namespace Weapon
{
    public abstract class BaseShootingWeapon : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 1f)] protected float TimeBetweenShoting;

        [SerializeField] protected GameObject Bullet;

        protected float Timer { get; private set; }

        protected abstract void Shot();

        private void Update()
        {
            Shot();

            Timer += Time.deltaTime;
        }

        protected void ResetTimer()
        {
            Timer = 0;
        }
    }
}
