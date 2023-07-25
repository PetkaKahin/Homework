namespace Task_6___Decorator
{
    public class BasePassiveAbility : ICharacterStats
    {
        protected readonly ICharacterStats Stats;
        protected readonly BasePassiveAbilityConfig Config;

        public BasePassiveAbility(ICharacterStats stats, BasePassiveAbilityConfig config)
        {
            Stats = stats;
            Config = config;
        }

        public int MaxHealth => Stats.MaxHealth;

        public int Health => Stats.Health;

        public int Agility => Stats.Agility;

        public int Intellect => Stats.Intellect;

        public virtual void Heal(int value) => Stats.Heal(value);

        public virtual void TakeDamage(int damage) => Stats.TakeDamage(damage);
    }
}
