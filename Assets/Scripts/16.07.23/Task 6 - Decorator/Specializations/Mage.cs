namespace Task_6___Decorator
{
    public class Mage : BaseSpecialization
    {
        private const int AdditionalHeal = 3;

        public Mage(ICharacterStats stats, BaseSpecializationConfig config) : base(stats, config)
        {
            
        }

        public override void Heal(int value) => base.Heal(value + AdditionalHeal);
    }
}
