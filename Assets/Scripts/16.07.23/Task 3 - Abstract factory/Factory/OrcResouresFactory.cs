using UnityEngine;

namespace Task_3___Abstract_factory
{
    public class OrcResouresFactory : AbstractResoursesFactory
    {
        [SerializeField] private OrcCoin _orcCoin;
        [SerializeField] private OrcEnergy _orcEnergy;

        public override BaseCoin GetCoin(Transform parent) => Instantiate(_orcCoin, parent);

        public override BaseEnergy GetEnergy(Transform parent) => Instantiate(_orcEnergy, parent);

    }
}
