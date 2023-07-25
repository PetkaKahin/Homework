using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner : MonoBehaviour, IEnemyDeathNotifier
    {
        [SerializeField, Range(0, 1000)] private int _maxWeight;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;

        private EnemySpawnVisiter _enemySpawnVisiter = new EnemySpawnVisiter();
        private EnemyDieVisiter _enemyDieVisiter = new EnemyDieVisiter();

        private int _weight => _enemySpawnVisiter.Weight + _enemyDieVisiter.Weight;

        public event Action<Enemy> Notified;

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if(_spawnedEnemies.Count <= 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Die();
            StartWork();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnCooldown);

                EnemyType randomenemyType = (EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
                Transform randomSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];

                Enemy enemy = _enemyFactory.Get(randomenemyType, randomSpawnPoint);
                _enemySpawnVisiter.Visit(enemy);
                

                if (_weight > _maxWeight)
                {
                    _enemyDieVisiter.Visit(enemy);
                    enemy.Die();
                    Debug.Log($"Нет места для спавна для {enemy}\t Вес: {_weight}");
                    break;
                }
                
                _spawnedEnemies.Add(enemy);
                enemy.Died += OnEnemyDied;
                Debug.Log($"Спавн врага {enemy}\t Вес: {_weight}");
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
            _enemyDieVisiter.Visit(enemy);
        }

        private class EnemySpawnVisiter : IEnemyVisitor
        {
            public int Weight { get; private set; }

            public void Visit(Ork ork) => Weight += 15;

            public void Visit(Human human) => Weight += 10;

            public void Visit(Elf elf) => Weight += 5;

            public void Visit(Robot robot) => Weight += 20;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }

        private class EnemyDieVisiter : IEnemyVisitor
        {
            public int Weight { get; private set; }

            public void Visit(Ork ork) => Weight -= 15;

            public void Visit(Human human) => Weight -= 10;

            public void Visit(Elf elf) => Weight -= 5;

            public void Visit(Robot robot) => Weight -= 20;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}
