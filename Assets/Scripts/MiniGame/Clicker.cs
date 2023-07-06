using UnityEngine;

namespace MiniGame
{
    public class Clicker : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 rayPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y));

                Ray ray = new Ray(rayPosition, Vector3.down);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out Ball ball))
                    {
                        ball.DestroyBall();
                    }
                }
            }
        }
    }
}

