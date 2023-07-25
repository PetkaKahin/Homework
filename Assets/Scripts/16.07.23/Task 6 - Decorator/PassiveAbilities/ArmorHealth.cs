using UnityEngine;

namespace Task_6___Decorator
{
    public class ArmorHealth : BasePassiveAbility
    {
        [SerializeField] private int _armor;

        public ArmorHealth(ICharacterStats stats, ArmorHeathConfig config) : base(stats, config)
        {
            _armor = config.Armor;
        }

        public override void TakeDamage(int damage)
        {
            damage -= _armor;
            Debug.Log($"Урона заблокированно: {_armor}");
            if (damage >= 0)
                Stats.TakeDamage(damage);
        }
    }
}
