using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGame
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
