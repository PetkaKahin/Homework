using UnityEngine;

namespace Mediator
{
    public class GameplayMediator : MonoBehaviour
    {
        [SerializeField] private BasePlayer _player;
        [SerializeField] private DefeatPanel _defeatPanel;

        private void OnEnable()
        {
            _player.Died += Defeat;
        }

        private void OnDisable()
        {
            _player.Died -= Defeat;
        }

        public void Restart()
        {
            _player.ResetStats();
            _defeatPanel.Hide();
        }

        private void Defeat()
        {
            _defeatPanel.Show();
        }
    }
}
