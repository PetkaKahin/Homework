using UnityEngine;

namespace Task_4___Spawner_Coin
{
    public class SpawnPoint : MonoBehaviour
    {
        private Coin _coin;

        public Transform Transform => transform;

        public bool IsVoid => _coin == null;

        public void SetCoin(Coin coin) => _coin = coin;
    }
}
