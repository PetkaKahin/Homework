using System;

namespace Task_2___Mediator
{
    public class PlayerExperience : IExperience
    {
        private const int DefaultLevel = 1;

        public PlayerExperience(float maxExperience)
        {
            MaxExperience = maxExperience;
            Level = DefaultLevel;
        }

        public float Experience { get; private set; }

        public float MaxExperience { get; private set; }

        public int Level { get; private set; }

        public event Action LeveledUp;

        public void TakeExpirience(float experience)
        {
            if (experience < 0)
                throw new ArgumentOutOfRangeException(nameof(experience));

            Experience += experience;

            if (Experience >= MaxExperience)
                LevelUp();
        }

        private void LevelUp()
        {
            Experience -= (Experience);

            Level++;

            MaxExperience *= Level;

            LeveledUp?.Invoke();
        }
    }
}
