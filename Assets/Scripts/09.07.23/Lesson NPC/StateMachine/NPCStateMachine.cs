namespace Lesson_NPC
{
    public class NPCStateMachine : IStateSwither
    {
        private readonly NPCData _npcData;

        private IState _currentState;

        public NPCStateMachine(NPCData npcData)
        {
            _npcData = npcData;

            IState defaultState = new WalkState(_npcData, this);
            
            _currentState = defaultState;
            _currentState.Enter();
        }

        public void SwitchState(IState newState)
        {
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
