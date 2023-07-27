namespace Task_6___Decorator
{
    public class Barbarian : BaseSpecialization
    {
        private const float IgnoridDamage = 0.1f;

        public Barbarian(ICharacterStats stats, BaseSpecializationConfig config) : base(stats, config)
        { 
            
        }

        public override void TakeDamage(int damage) => base.TakeDamage(damage - (int)(damage * IgnoridDamage));
    }
}
