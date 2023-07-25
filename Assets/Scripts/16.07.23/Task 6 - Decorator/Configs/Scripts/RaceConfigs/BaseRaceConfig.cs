using UnityEngine;

namespace Task_6___Decorator
{
    [CreateAssetMenu(fileName = "New RaceConfig", menuName = "Characters/RaceConfigs/RaceConfig")]
    public class BaseRaceConfig : ScriptableObject
    {
        [SerializeField] private int _agility;
        [SerializeField] private int _intellect;
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;

        public int Agility => _agility;
        public int Intellect => _intellect;
        public int Health => _health;

        public int MaxHealth => _maxHealth;
    }
}
