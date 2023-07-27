using System;

namespace Task_2___Mediator
{
    public interface IHealth
    {
        float Health { get; }
        float MaxHealth { get; }
        bool IsFullHealth { get; }

        public event Action Died;
        public event Action Healed;

        void TakeDamage(float damage);
        void Heal(float value);
        void SetMaxHealth(float newMaxHealth);
    }
}
