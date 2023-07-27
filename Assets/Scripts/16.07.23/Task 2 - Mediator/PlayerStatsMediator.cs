using UnityEngine;

namespace Mediator
{
    public class PlayerStatsMediator : MonoBehaviour
    {
        [SerializeField] private StatsPanel _statsPanel;

        public void SetHealth(float health, int maxHeath) => _statsPanel.HealthUpdate(health, maxHeath);
            
        public void SetMaxHealth(int value) => _statsPanel.MaxHealthUpdate(value);

        public void SetExperience(float experience, int maxExperience) => _statsPanel.ExperienceUpdate((int)experience, maxExperience);

        public void SetMaxExperience(int value) => _statsPanel.MaxExperienceUpdate(value);

        public void SetLevel(int value) => _statsPanel.LevelUpdate(value);
    }
}
