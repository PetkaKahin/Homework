namespace Task_6___Decorator
{
    public class Thief : BaseSpecialization
    {
        private const float MultiplyAgility = 1.4f;

        public Thief(ICharacterStats stats, BaseSpecializationConfig config) : base(stats, config)
        {

        }

        public override int Agility => (int)(base.Agility * MultiplyAgility);
    }
}
