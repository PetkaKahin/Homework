using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Range(5f, 100f)] private float _speed;

        private void Update()
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime);
        }
    }
}
