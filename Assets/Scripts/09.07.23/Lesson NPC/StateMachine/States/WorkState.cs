using UnityEngine;

namespace Lesson_NPC
{
    public class WorkState : BaseState
    {
        public WorkState(NPCData npcData, IStateSwither stateSwither) : base(npcData, stateSwither) { }

        public override void Enter()
        {
            Debug.Log($"Начинаю работать :(");
        }

        public override void Exit()
        {
            Debug.Log($"Я устал... Я ухожу...");
        }

        public override void Update()
        {
            if (NpcData.TrySpendStamina(NpcData.SpeedFatigue * Time.deltaTime) == false)
            {
                StateSwither.SwitchState<WalkState>();
            }
        }
    }
}
