using UnityEngine;

namespace NPC_traider
{
    public class NormalTrader : TraderNPC
    {
        [SerializeField][Range(ITrader.MinReputation, ITrader.MaxReputation)] private int _requiredReputetionForFrutis;
        [SerializeField][Range(ITrader.MinReputation, ITrader.MaxReputation)] private int _requiredReputetionForArmor;

        protected override ITrader ReputationChek(int reputation)
        {
            if (reputation >= _requiredReputetionForArmor)
                return new ArmorTrade();
            if (reputation >= _requiredReputetionForFrutis)
                return new FruitsTrade();

            return new NoTrade();
        }
    }
}
