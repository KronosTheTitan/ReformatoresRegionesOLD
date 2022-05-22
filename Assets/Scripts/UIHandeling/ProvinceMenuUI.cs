using GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace UIHandeling
{
    public class ProvinceMenuUI : Menu
    {
        [SerializeField] private Text levelText;
        [SerializeField] private Province parent;
    
        public override void OpenMenu()
        {
            base.OpenMenu();
            levelText.text = "Level = "+parent.develpomentLevel.ToString();
        }

        public void IncreaseLevel()
        {
            parent.IncreaseDevelopment();
            levelText.text = "Level = "+parent.develpomentLevel.ToString();
        }
    }
}
