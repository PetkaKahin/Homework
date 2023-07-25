using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mediator
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _maxHealthText;
        [SerializeField] private TMP_Text _experienceText;
        [SerializeField] private TMP_Text _maxExperienceText;
        [SerializeField] private TMP_Text _LevelText;

        [Space]
        [SerializeField] private Scrollbar _healthScrollbar;
        [SerializeField] private Scrollbar _experienceScrollbar;

        public void HealthUpdate(float health, int maxHeath)
        {
            TextUpdate(_healthText, ((int)health).ToString());

            ScrollbarUpdate(_healthScrollbar, health, maxHeath);
        }

        public void ExperienceUpdate(int experience, int maxExperience) 
        {
            TextUpdate(_experienceText, experience.ToString());

            ScrollbarUpdate(_experienceScrollbar, experience, maxExperience);
        }

        public void MaxHealthUpdate(float maxHealth) => TextUpdate(_maxHealthText, maxHealth.ToString());

        public void MaxExperienceUpdate(int maxExperience) => TextUpdate(_maxExperienceText, maxExperience.ToString());

        public void LevelUpdate(int level) => TextUpdate(_LevelText, level.ToString());

        private void ScrollbarUpdate(Scrollbar scrollbar, float value, float maxValue)
        {
            if (value > 0)
                scrollbar.size = value / maxValue;
            else
                scrollbar.size = 0;
        }

        private void TextUpdate(TMP_Text textUI, string text) => textUI.text = text;
    }
}

