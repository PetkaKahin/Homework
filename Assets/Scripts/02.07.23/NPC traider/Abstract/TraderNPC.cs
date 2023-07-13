using UnityEngine;

namespace NPC_traider
{
    public abstract class TraderNPC : MonoBehaviour
    {
        public virtual void Trade(int reputation)
        {
            ReputationChek(reputation).Trade();
        }

        protected virtual ITrader ReputationChek(int reputation)
        {
            return new NoTrade();
        }
    }
}
