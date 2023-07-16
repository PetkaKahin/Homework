using System;
using UnityEngine;

namespace Lesson_NPC
{
    public class NPCData
    {
        private readonly float _maxStamina;
        private readonly float _minStamina;

        private readonly Transform _npcTransform;

        public bool IsRelax => Stamina == _maxStamina ? true : false;

        public float Stamina { get; private set; }
        public float Speed { get; private set; }
        public float SpeedRegenerationStamina { get; private set; }
        public float SpeedFatigue { get; private set; }

        public Vector3 WorkPosition { get; set; }
        public Vector3 RelaxPosition { get; set; }
        public Vector3 CurrentPosition => _npcTransform.position;

        public NPCData(float MaxStamina, float MinStamina, Transform npcTransform)
        {
            _maxStamina = MaxStamina;
            _minStamina = MinStamina;

            _npcTransform = npcTransform;

            Stamina = _maxStamina;
        }

        public void SetSpeed(float speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            Speed = speed;
        }

        public void SetSpeedRegenerationStamina(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            SpeedRegenerationStamina = value;
        }

        public void SetSpeedFatigue(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            SpeedFatigue = value;
        }

        public bool TryRegenerationStamina(float speed)
        {
            if (Stamina + speed < _maxStamina)
            {
                Stamina += speed;
            }
            else
            {
                Stamina = _maxStamina;
                return false;
            }

            return true;
        }

        public bool TrySpendStamina(float count)
        {
            if (Stamina - count > _minStamina)
            {
                Stamina -= count;
            }
            else
            {
                Stamina = _minStamina;
                return false;
            }

            return true;
        }
    }
}
