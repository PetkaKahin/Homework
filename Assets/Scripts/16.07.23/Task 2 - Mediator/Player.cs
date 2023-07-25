using System;
using System.Collections;
using UnityEngine;

namespace Mediator
{
    public class Player : BasePlayer
    {
        private const int DefaultLevel = 1;

        [SerializeField] private int _defaultHealth;
        [SerializeField] private int _healthRegeniration;
        [SerializeField] private int _defaulExperience;

        [SerializeField] private PlayerStatsMediator _playerStatsMediator;

        private float _health;

        private int _maxHealth;
        private int _maxExperience;
        private int _experience;
        private int _level;

        private bool _isRegeneration;

        public override event Action Died; 

        private void Start()
        {
            ResetStats();
        }

        public override void ResetStats()
        {
            _isRegeneration = true;
            StartCoroutine(Regeneration());

            _health = _defaultHealth;

            _maxHealth = _defaultHealth;
            _maxExperience = _defaulExperience;
            _level = DefaultLevel;

            _playerStatsMediator.SetHealth(_health, _maxHealth);
            _playerStatsMediator.SetMaxHealth(_maxHealth);
            _playerStatsMediator.SetExperience(_experience, _maxExperience);
            _playerStatsMediator.SetMaxExperience(_maxExperience);
            _playerStatsMediator.SetLevel(_level);
        }

        public override void TakeExperience(int experience)
        {
            if (experience < 0)
                throw new ArgumentOutOfRangeException(nameof(experience));

            _experience += experience;

            if (_experience >= _maxExperience)
                LevelUp();

            _playerStatsMediator.SetExperience(_experience, _maxExperience);
        }

        public override void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health -= damage;

            if (_health <= 0)
                Die();
        }

        private void LevelUp()
        {
            _experience -= (_maxExperience);

            _level++;

            _maxHealth *= _level;
            _maxExperience *= _level;

            _playerStatsMediator.SetLevel(_level);
            _playerStatsMediator.SetMaxExperience(_maxExperience);
            _playerStatsMediator.SetMaxHealth(_maxHealth);
        }

        private IEnumerator Regeneration()
        {
            while (_isRegeneration)
            {
                float regeniration = _healthRegeniration * Time.deltaTime;

                if (_health <= _maxHealth)
                {
                    _health += regeniration;

                    if (_health > _maxHealth)
                        _health = _maxHealth;

                    _playerStatsMediator.SetHealth(_health, _maxHealth);
                }

                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        private void Die()
        {
            _isRegeneration = false;

            Died?.Invoke();
        }
    }
}

