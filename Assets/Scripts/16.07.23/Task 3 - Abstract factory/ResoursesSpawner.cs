using UnityEngine;

namespace Task_3___Abstract_factory
{
    public class ResoursesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _ParentSpawnPoin;

        [SerializeField] private AbstractResoursesFactory _Factory;

        public void SpawnEnergy()
        {
            _Factory.GetEnergy(_ParentSpawnPoin);
        }

        public void SpawnCoin()
        {
            _Factory.GetCoin(_ParentSpawnPoin);
        }
    }
}

