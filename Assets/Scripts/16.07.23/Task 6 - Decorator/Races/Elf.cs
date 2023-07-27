namespace Task_6___Decorator
{
    public class Elf : BaseRace
    {
        private const int AdditionalAgility = 2;
        public Elf(BaseRaceConfig config) : base(config)
        {
        }

        public override int Agility => base.Agility + AdditionalAgility;
    }
}
