using UnityEngine;

namespace NPC_traider
{
    public class Player : MonoBehaviour
    {
        [SerializeField] [Range(1, 25)] private float _speed;
        [field: SerializeField, Range(ITrader.MinReputation, ITrader.MaxReputation)] public int Reputation { get; private set; }

        private Vector3 _direction;

        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TraderNPC traider))
            {
                traider.Trade(Reputation);
            }
        }
    }
}
