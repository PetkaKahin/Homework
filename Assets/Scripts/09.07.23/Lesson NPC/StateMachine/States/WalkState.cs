using UnityEngine;

namespace Lesson_NPC
{
    public class WalkState : BaseState
    {
        private const float InaccuracyDistance = 0.1f;

        private Vector3 _target;
        private IMover _npc;



        public WalkState(NPCData npcData, IStateSwither stateSwither, IMover npc) : base(npcData, stateSwither)
        {
            _npc = npc;
        }



        public override void Enter()
        {
            if (NpcData.IsRelax)
            {
                Debug.Log("Иду на завод :(");
                _target = NpcData.WorkPosition;
            }
            else
            {
                Debug.Log("УРАААА! Лечу домой!");
                _target = NpcData.RelaxPosition;
            }
        }

        public override void Exit()
        {
            Debug.Log("Я пришел");
        }

        public override void Update()
        {
            if (Vector3.Distance(NpcData.CurrentPosition, _target) > InaccuracyDistance)
            {
                Vector3 direction = _target * NpcData.Speed * Time.deltaTime;
                _npc.Move(direction);
            }
            else
            {
                if (NpcData.IsRelax)
                    StateSwither.SwitchState<WorkState>();
                else
                    StateSwither.SwitchState<RelaxState>();
            }
        }
    }
}
