namespace Lesson_NPC
{
    public class BaseState : IState
    {
        protected readonly IStateSwither StateSwither;

        protected readonly NPCData NpcData;

        public BaseState(NPCData npcData, IStateSwither stateSwither)
        {
            NpcData = npcData;
            StateSwither = stateSwither;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
