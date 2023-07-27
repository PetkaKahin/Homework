using System;
using System.Collections;
using UnityEngine;

namespace Task_2___Mediator
{
    public class PlayerHealth : IHealth
    {
        private readonly float _regeniration;

        private readonly MonoBehaviour _parent;

        private bool _isRegeniration;

        public PlayerHealth(float maxHealth, float regeniration, MonoBehaviour parent)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;

            _regeniration = regeniration;
            _parent = parent;

            _isRegeniration = true;

            _parent.StartCoroutine(Regeneration());
        }

        public float Health { get; private set; }

        public float MaxHealth { get; private set; }

        public bool IsFullHealth => Health == MaxHealth;

        public event Action Died;
        public event Action Healed;

        public void Heal(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Health += value;

            if (Health > MaxHealth)
                Health = MaxHealth;

            Healed?.Invoke();
        }

        public void SetMaxHealth(float newMaxHealth)
        {
            if (newMaxHealth < 0)
                throw new ArgumentOutOfRangeException(nameof(newMaxHealth));

            MaxHealth = newMaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Health -= damage;

            if (Health <= 0)
            {
                _isRegeniration = false;
                Died?.Invoke();
            }
        }

        private IEnumerator Regeneration()
        {
            while (_isRegeniration)
            {
                if (IsFullHealth == false)
                {
                    float regeniration = _regeniration * Time.deltaTime;

                    Heal(regeniration);
                }

                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
