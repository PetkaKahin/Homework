namespace Task_6___Decorator
{
    public class BaseSpecialization : ICharacterStats
    {
        protected readonly ICharacterStats Stats;
        protected readonly BaseSpecializationConfig Config;

        public BaseSpecialization(ICharacterStats stats, BaseSpecializationConfig config)
        {
            Stats = stats;
            Config = config;
        }

        public virtual int Agility => Stats.Agility + Config.AdditionalAgility;

        public virtual int Intellect => Stats.Intellect + Config.AdditionalIntellect;

        public virtual int MaxHealth => Stats.MaxHealth + Config.AdditionalHealth;

        public virtual int Health => Stats.Health + Config.AdditionalHealth;

        public virtual void Heal(int value) => Stats.Heal(value);

        public virtual void TakeDamage(int damage) => Stats.TakeDamage(damage);
    }
}
