using UnityEngine;

namespace Task_6___Decorator
{
    [CreateAssetMenu(fileName = "New ArmorHeathConfig", menuName = "Characters/PassiveAbilityConfigs/ArmorHeathConfig")]
    public class ArmorHeathConfig : BasePassiveAbilityConfig
    {
        [SerializeField] private int _armor;

        public int Armor => _armor;
    }
}
