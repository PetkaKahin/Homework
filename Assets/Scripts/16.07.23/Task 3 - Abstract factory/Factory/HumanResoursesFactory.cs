using UnityEngine;

namespace Task_3___Abstract_factory
{
    public class HumanResoursesFactory : AbstractResoursesFactory
    {
        [SerializeField] private HumanCoin _humanCoin;
        [SerializeField] private HumanEnergy _humanEnergy;

        public override BaseCoin GetCoin(Transform parent) => Instantiate(_humanCoin, parent);

        public override BaseEnergy GetEnergy(Transform parent) => Instantiate(_humanEnergy, parent);
    }
}
