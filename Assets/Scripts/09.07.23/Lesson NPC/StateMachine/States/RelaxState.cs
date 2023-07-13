using UnityEngine;

namespace Lesson_NPC
{
    public class RelaxState : BaseState
    {
        public RelaxState(NPCData npcData, IStateSwither stateSwither) : base(npcData, stateSwither) { }

        public override void Enter()
        {
            Debug.Log($"*Звуки храпа работяги*");
        }

        public override void Exit()
        {
            Debug.Log($"С добрым утром");
        }

        public override void Update()
        {
            if (!NpcData.TryRegenerationStamina(NpcData.SpeedRegenerationStamina * Time.deltaTime))
            {
                StateSwither.SwitchState(new WalkState(NpcData, StateSwither));
            }
        }
    }
}
