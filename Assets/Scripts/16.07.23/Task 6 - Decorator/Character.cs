using System;
using UnityEngine;

namespace Task_6___Decorator
{
    public class Character : MonoBehaviour, ICharacterStats
    {
        [SerializeField] private BaseRaceConfig _raceConfig;
        [SerializeField] private BaseSpecializationConfig _specializationConfig;
        [SerializeField] private BasePassiveAbilityConfig _passiveAbilityConfig;

        private ICharacterStats _characterStats;

        public int MaxHealth => _characterStats.MaxHealth;
        public int Health => _characterStats.Health;
        public int Intellect => _characterStats.Intellect;
        public int Agility => _characterStats.Agility;

        public event Action Died;

        private void Start()
        {
            _characterStats = new ArmorHealth(new Thief(new Human(_raceConfig), _specializationConfig), (ArmorHeathConfig)_passiveAbilityConfig);
        }

        public void Heal(int value)
        {
            _characterStats.Heal(value);
            Debug.Log($"Хил: {value}  \tХП: {Health}");
        }

        public void TakeDamage(int damage)
        {
            _characterStats.TakeDamage(damage);
            Debug.Log($"урон: {damage}\tХП: {Health}");
            if (Health <= 0)
                Die();
        }

        private void Die()
        {
            Died?.Invoke();
        }
    }
}
