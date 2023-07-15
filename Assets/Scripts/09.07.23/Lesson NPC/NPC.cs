using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Lesson_NPC
{
    public class NPC : MonoBehaviour, IMover
    {
        private const float MinStamina = 0;
        private const float MaxStamina = 100;
        private const float MaxSpeed = 10;
        private const float MinSpeed = 0;

        [SerializeField] [Range(MinStamina, MaxStamina)] private float _fullStamina;
        [SerializeField] [Range(MinStamina, MaxStamina)] private float _staminaRegeneration;
        [SerializeField] [Range(MinStamina, MaxStamina)] private float _speedFatigue;
        [SerializeField] [Range(MinSpeed, MaxSpeed)] private float _speed;

        [SerializeField] private Transform _workPosition;
        [SerializeField] private Transform _realaxPosition;

        private NPCStateMachine _stateMachine;
        private NPCData _npcData;

        private void Start()
        {
            _npcData = new NPCData(_fullStamina, MinStamina, transform);
            
            _npcData.SetSpeed(_speed);
            _npcData.SetSpeedRegenerationStamina(_staminaRegeneration);
            _npcData.SetSpeedFatigue(_speedFatigue);

            _npcData.WorkPosition = _workPosition.position;
            _npcData.RelaxPosition = _realaxPosition.position;

            _stateMachine = new NPCStateMachine(_npcData, this);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Move(Vector3 direction)
        {
            transform.position += direction;
        }
    }
}

