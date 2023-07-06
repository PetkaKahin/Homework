using UnityEngine;

namespace NPC_traider
{
    public class NoTrade : ITrade
    {
        public void Trade()
        {
            Debug.Log("Я не буду торговать с тобой!");      
        }
    }
}

