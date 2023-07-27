namespace Task_6___Decorator
{
    public class Orc : BaseRace
    {
        private const int AdditionalHealth = 8;

        public Orc(BaseRaceConfig config) : base(config)
        {
        }

        public override int MaxHealth => base.MaxHealth + AdditionalHealth;
    }
}
