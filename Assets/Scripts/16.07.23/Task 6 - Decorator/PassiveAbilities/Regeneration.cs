using System.Collections;
using UnityEngine;

namespace Task_6___Decorator
{
    public class Regeneration : BasePassiveAbility
    {
        private RegenerationConfig _config;

        public Regeneration(ICharacterStats stats, RegenerationConfig config, MonoBehaviour context) : base(stats, config)
        {
            _config = config;

            context.StartCoroutine(Regenerate(config.HealPerTick, config.TickTime));
        }

        private IEnumerator Regenerate(int value, float coolDown) 
        {
            while (_config.IsRegeneration)
            {
                if (Health < MaxHealth)
                {
                    Debug.Log($"Регенерация: {value}");
                    Heal(value);
                }

                yield return new WaitForSeconds(coolDown);
            }
        }
    }
}
