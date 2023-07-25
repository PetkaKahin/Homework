using UnityEngine;

namespace Task_3___Abstract_factory
{
    public abstract class AbstractResoursesFactory : MonoBehaviour
    {
        public abstract BaseEnergy GetEnergy(Transform parent);

        public abstract BaseCoin GetCoin(Transform parent);
    }
}