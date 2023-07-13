using UnityEngine;

namespace Lesson_NPC
{
    public class WalkState : BaseState
    {
        private const float InaccuracyDistance = 0.1f; // погрешность

        public WalkState(NPCData npcData, IStateSwither stateSwither) : base(npcData, stateSwither) { }

        private Vector3 _target;
        private BaseState _nextState;

        public override void Enter()
        {
            if (NpcData.IsRelax)
            {
                Debug.Log("Иду на завод :(");
                _target = NpcData.WorkPosition;
                _nextState = new WorkState(NpcData, StateSwither);
            }
            else
            {
                Debug.Log("УРАААА! Лечу домой!");
                _target = NpcData.RelaxPosition;
                _nextState = new RelaxState(NpcData, StateSwither);
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
                NpcData.Mover.Move(direction);
            }
            else
            {
                StateSwither.SwitchState(_nextState);
            }
        }
    }
}
