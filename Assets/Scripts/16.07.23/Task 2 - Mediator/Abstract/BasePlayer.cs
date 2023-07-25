using System;
using UnityEngine;

namespace Mediator
{
    public abstract class BasePlayer : MonoBehaviour
    {
        public abstract event Action Died;

        public abstract void TakeDamage(int damege);
        public abstract void TakeExperience(int experience);
        public abstract void ResetStats();
    }
}
