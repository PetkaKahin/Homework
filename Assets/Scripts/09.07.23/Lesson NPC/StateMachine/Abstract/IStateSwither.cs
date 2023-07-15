namespace Lesson_NPC
{
    public interface IStateSwither
    {
        void SwitchState<T>() where T : IState;
    }
}
