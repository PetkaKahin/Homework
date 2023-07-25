using UnityEngine;

namespace Task_6___Decorator
{
    [CreateAssetMenu(fileName = "New RegenerationConfig", menuName = "Characters/PassiveAbilityConfigs/RegenerationConfig")]
    public class RegenerationConfig : BasePassiveAbilityConfig
    {
        [SerializeField] private bool _isRegeniration;

        [SerializeField] private int _healPerTick;

        [SerializeField] private float _tickTime;

        public bool IsRegeneration => _isRegeniration;

        public int HealPerTick => _healPerTick;

        public float TickTime => _tickTime;
    }
}
