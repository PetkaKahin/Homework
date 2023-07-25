using System.Collections.Generic;
using UnityEngine;

namespace Task_4___Spawner_Coin
{
    public class SpawnCoins : MonoBehaviour
    {
        private const int MinListIndex = 0;

        [SerializeField] private CoinFactory _factory;

        [SerializeField] private List<Transform> _spawnpoints = new List<Transform>();

        private List<Transform> _emptySpawnPoints;
        private List<Coin> _coins = new List<Coin>();

        private void Start()
        {
            _emptySpawnPoints = new List<Transform>(_spawnpoints);
        }

        public void CreateRandomCoin()
        {
            if (_emptySpawnPoints.Count == MinListIndex)
            {
                Debug.Log("Нет места, спавт отменяется(");
                return;
            }

            int randomIndex = Random.Range(MinListIndex, _emptySpawnPoints.Count);

            _coins.Add(_factory.Get(_emptySpawnPoints[randomIndex]));
            _emptySpawnPoints.RemoveAt(randomIndex);
        }
    }
}