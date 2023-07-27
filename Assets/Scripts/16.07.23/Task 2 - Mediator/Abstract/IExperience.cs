using System;

namespace Task_2___Mediator
{
    public interface IExperience
    {
        float Experience { get; }
        float MaxExperience { get; }
        int Level { get; }

        event Action LeveledUp;

        void TakeExpirience(float value);
    }
}
