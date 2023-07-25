using UnityEngine;

namespace Task_6___Decorator
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [SerializeField] private int _damage;
        [SerializeField] private int _heal;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _character.TakeDamage(_damage);
            if (Input.GetKeyDown(KeyCode.F))
                _character.Heal(_heal);
        }
    }
}

