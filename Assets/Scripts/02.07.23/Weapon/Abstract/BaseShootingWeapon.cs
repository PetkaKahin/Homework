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

        public void StartShot() => IsCanShot = false;

        public void EndShot()
        {
            IsCanShot = true;
            ResetTimer();
        }

        public virtual void Shot()
        {
            if (!IsCanShot)
                return;
            
            StartShot();
            CreateBullet(transform);
        }

        protected virtual void ChekRecharge()
        {
            if (Timer >= TimeBetweenShoting)
            {
                EndShot();
            }
        }

        protected void CreateBullet(Transform position)
        {
            if (Bullet == null)
                throw new NullReferenceException("Bullet");

            Instantiate(Bullet.gameObject, position);
        }

        private void ResetTimer()
        {
            Timer = 0;
        }
    }
}
