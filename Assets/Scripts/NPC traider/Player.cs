using UnityEngine;

namespace NPC_traider
{
    public class Player : MonoBehaviour
    {
        [SerializeField] [Range(1, 25)] float _speed;
        [SerializeField] [Range(0, 10)] private int _reputation;

        private Vector3 _direction;

        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TraiderNPC traider))
            {
                if (_reputation > 7)
                {
                    traider.Trade(new ArmorTrade());
                    return;
                }
                if (_reputation > 3)
                {
                    traider.Trade(new FruitsTrade());
                    return;
                }   
                traider.Trade(new NoTrade());
            }
        }
    }
}
