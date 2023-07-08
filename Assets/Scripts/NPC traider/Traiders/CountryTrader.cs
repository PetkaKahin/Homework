using UnityEngine;

namespace NPC_traider
{
    public class CountryTrader : TraderNPC
    {
        [SerializeField] [Range(ITrader.MinReputation, ITrader.MaxReputation)] private int _requiredReputetionForFrutis;

        protected override ITrader ReputationChek(int reputation)
        {
            if (reputation >= _requiredReputetionForFrutis)
                return new FruitsTrade();

            return new NoTrade();
        }
    }
}
