using UnityEngine;

namespace Task_4___Spawner_Coin
{
    public class CoinFactory : MonoBehaviour
    {
        [SerializeField] private Coin _coin;

        public Coin Get(Transform parent) => Instantiate(_coin, parent);
    }
}
