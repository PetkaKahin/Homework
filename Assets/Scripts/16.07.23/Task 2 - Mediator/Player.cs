using System;
using Task_2___Mediator;
using UnityEngine;

namespace Mediator
{
    public class Player : BasePlayer
    {
        [SerializeField] private int _defaultHealth;
        [SerializeField] private int _healthRegeniration;
        [SerializeField] private int _defaulExperience;

        [SerializeField] private PlayerStatsMediator _playerStatsMediator;

        private IHealth _playerHealth;
        private IExperience _playerExperience;

        private float _health => _playerHealth.Health;
        private float _maxHealth => _playerHealth.MaxHealth;
        private float _experience => _playerExperience.Experience;
        private float _maxExperience => _playerExperience.MaxExperience;

        private int _level => _playerExperience.Level;

        public override event Action Died;

        private void Awake()
        {
            ResetStats();
        }

        private void OnEnable()
        {
            _playerExperience.LeveledUp += LevelUp;

            _playerHealth.Died += Die;
            _playerHealth.Healed += Heal;
        }

        private void OnDisable()
        {
            _playerExperience.LeveledUp -= LevelUp;

            _playerHealth.Died -= Die;
            _playerHealth.Healed -= Heal;
        }

        public override void ResetStats()
        {
            _playerHealth = new PlayerHealth(_defaultHealth, _healthRegeniration, this);
            _playerExperience = new PlayerExperience(_defaultHealth);

            _playerStatsMediator.SetHealth(_health, (int)_maxHealth);
            _playerStatsMediator.SetMaxHealth((int)_maxHealth);
            _playerStatsMediator.SetExperience(_experience, (int)_maxExperience);
            _playerStatsMediator.SetMaxExperience((int)_maxExperience);
            _playerStatsMediator.SetLevel(_level);

            OnDisable();
            OnEnable();
        }

        public override void TakeExperience(int experience)
        {
            _playerExperience.TakeExpirience(experience);
            _playerStatsMediator.SetExperience(_experience, (int)_maxExperience);
        }

        public override void TakeDamage(int damage)
        {
            _playerHealth.TakeDamage(damage);
            _playerStatsMediator.SetHealth(_health, (int)_maxHealth);
        }

        private void LevelUp()
        {
            _playerStatsMediator.SetMaxHealth((int)_maxHealth);
            _playerStatsMediator.SetExperience(_experience, (int)_maxExperience);
            _playerStatsMediator.SetMaxExperience((int)_maxExperience);
            _playerStatsMediator.SetLevel(_level);

            _playerHealth.SetMaxHealth(_maxHealth * _level);
        }

        private void Heal() => _playerStatsMediator.SetHealth(_health, (int) _maxHealth);

        private void Die() => Died?.Invoke();
    }
}

