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

        public int Agility => Stats.Agility + Config.AdditionalAgility;

        public int Intellect => Stats.Intellect + Config.AdditionalIntellect;

        public int MaxHealth => Stats.MaxHealth + Config.AdditionalHealth;

        public int Health => Stats.Health + Config.AdditionalHealth;

        public void Heal(int value) => Stats.Heal(value);

        public void TakeDamage(int damage) => Stats.TakeDamage(damage);
    }
}
