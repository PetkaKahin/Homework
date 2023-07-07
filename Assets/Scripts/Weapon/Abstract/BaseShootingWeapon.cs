using System;
using UnityEngine;

namespace Weapon
{
    public abstract class BaseShootingWeapon : MonoBehaviour
    {
        [field : SerializeField, Range(0.1f, 1f)] public float TimeBetweenShoting { get; private set; }

        [SerializeField] private Bullet Bullet;

        public float Timer { get; private set; } = 0;

        public bool IsCanShot { get; protected set; } = true;

        private void Update()
        {
            Timer += Time.deltaTime;
            ChekRecharge();
        }

        public virtual void Shot()
        {
            if (!IsCanShot)
                return;

            IsCanShot = false;

            CreateBullet(transform);
            ResetTimer();
        }

        protected virtual void ChekRecharge()
        {
            
            if (Timer >= TimeBetweenShoting)
            {
                ResetTimer();
                IsCanShot = true;
            }
        }

        protected void ResetTimer()
        {
            Timer = 0;
        }

        protected void CreateBullet(Transform position)
        {
            if (Bullet == null)
                throw new NullReferenceException("Bullet");

            Instantiate(Bullet.gameObject, position);
        }
    }
}
