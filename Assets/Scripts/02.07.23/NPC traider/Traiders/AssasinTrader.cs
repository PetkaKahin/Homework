using UnityEngine;

namespace NPC_traider
{
    public class AssasinTrader : TraderNPC
    {
        [SerializeField] [Range(ITrader.MinReputation, ITrader.MaxReputation)] private int _requiredReputetionForArmor;

        protected override ITrader ReputationChek(int reputation)
        {
            if (reputation <= _requiredReputetionForArmor)
                return new ArmorTrade();

            return new NoTrade();
        }
    }
}
