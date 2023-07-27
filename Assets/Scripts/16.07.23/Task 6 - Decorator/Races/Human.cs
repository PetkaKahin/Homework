namespace Task_6___Decorator
{
    public class Human : BaseRace
    {
        private const int AdditionalIntellect = 2;

        public Human(BaseRaceConfig config) : base(config)
        {

        }

        public override int Intellect => base.Intellect + AdditionalIntellect;
    }
}
