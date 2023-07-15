using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

namespace Lesson_NPC
{
    public class NPCStateMachine : IStateSwither
    {
        private readonly List<IState> _states = new List<IState>();

        private IState _currentState;

        public NPCStateMachine(NPCData npcData, IMover npc)
        {
            _states.Add(new RelaxState(npcData, this));
            _states.Add(new WalkState(npcData, this, npc));
            _states.Add(new WorkState(npcData, this));

            IState defaultState = _states[0];
            _currentState = defaultState;
        }

        public void SwitchState<T>() where T : IState
        {
            IState newState = _states.FirstOrDefault(newState => newState is T);

            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Update();
        }
    }
}
