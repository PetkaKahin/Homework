using System;

namespace Task_6___Decorator
{
    public class BaseRace : ICharacterStats
    {
        private BaseRaceConfig _config;

        public BaseRace(BaseRaceConfig config) 
        {
            _config = config;
            Health = MaxHealth;
        }

        public int Agility => _config.Agility;

        public int Intellect => _config.Intellect;

        public int MaxHealth => _config.MaxHealth;

        public int Health { get; private set; }

        public virtual void Heal(int value)
        {
            if (value < 0)
                throw new ArgumentException(nameof(value));

            Health += value;

            if (Health > MaxHealth)
                Health = MaxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException(nameof(damage));

            Health -= damage;
        }
    }
}
