using UnityEngine;

namespace NPC_traider
{
    public class TraiderNPC : MonoBehaviour
    {
        public void Trade(ITrade trader)
        {
            trader.Trade();
        }
    }
}
