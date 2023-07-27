using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task_4___Spawner_Coin
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private CoinFactory _factory;

        [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        public void CreateRandomCoin()
        {
            SpawnPoint NewspawnPoint = _spawnPoints.FirstOrDefault(spawnPoint => spawnPoint.IsVoid == true);

            if (NewspawnPoint != null)
                NewspawnPoint.SetCoin(_factory.Get(NewspawnPoint.Transform));
            else
                Debug.Log("Нету места, спавн отменяеется");
        }
    }
}