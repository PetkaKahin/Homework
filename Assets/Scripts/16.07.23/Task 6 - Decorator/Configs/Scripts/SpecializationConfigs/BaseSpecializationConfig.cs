using UnityEngine;

namespace Task_6___Decorator
{
    [CreateAssetMenu(fileName = "New SpecializationConfig", menuName = "Characters/SpecializationConfigs/SpecializationConfig")]
    public class BaseSpecializationConfig : ScriptableObject
    {
        [SerializeField] private int _additionalAgility;
        [SerializeField] private int _additionalIntellect;
        [SerializeField] private int _additionalHealth;

        public int AdditionalAgility => _additionalAgility;
        public int AdditionalIntellect => _additionalIntellect;
        public int AdditionalHealth => _additionalHealth;
    }
}
