using UnityEngine;

namespace Mediator
{
    public class DefeatPanel : MonoBehaviour
    {
        public void Enter() => gameObject.SetActive(true);

        public void Exit() => gameObject.SetActive(false);
    }
}
