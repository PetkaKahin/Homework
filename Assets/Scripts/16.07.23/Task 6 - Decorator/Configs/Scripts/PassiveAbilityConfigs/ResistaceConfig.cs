using UnityEngine;

namespace Task_6___Decorator
{
    [CreateAssetMenu(fileName = "New ResistaceConfig", menuName = "Characters/PassiveAbilityConfigs/ResistaceConfig")]
    public class ResistaceConfig : BasePassiveAbilityConfig
    {
        [SerializeField] float _resist;

        public float Resist => _resist;
    }
}
