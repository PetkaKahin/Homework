using UnityEngine;

namespace Task_6___Decorator
{
    public class Resistance : BasePassiveAbility
    {
        private const float MaxResist = 1;
        private const float MinResist = 0;

        [SerializeField] private float _resist;

        public Resistance(ICharacterStats stats, ResistaceConfig config) : base(stats , config)
        {
            float resist = config.Resist;

            if (resist > MinResist)
            {
                if (resist > MaxResist)
                {
                    resist = MaxResist;
                }
                _resist = resist;   
            }
        }

        public override void Heal(int value) => CalculateResist(value);

        public override void TakeDamage(int damage) => CalculateResist(damage);

        private int CalculateResist(int value) => (int)(value / (1 + _resist));
    }
}
