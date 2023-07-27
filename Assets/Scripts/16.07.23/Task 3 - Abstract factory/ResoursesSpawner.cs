using UnityEngine;

namespace Task_3___Abstract_factory
{
    public class ResoursesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _parentSpawnPoin;

        [SerializeField] private AbstractResoursesFactory _factory;

        public void SpawnEnergy() => _factory.GetEnergy(_parentSpawnPoin);

        public void SpawnCoin() => _factory.GetCoin(_parentSpawnPoin);
    }
}

