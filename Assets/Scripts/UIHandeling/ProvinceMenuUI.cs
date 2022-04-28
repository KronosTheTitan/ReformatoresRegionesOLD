using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (parent.develpomentLevel > 2) return;
        parent.develpomentLevel++;
        levelText.text = "Level = "+parent.develpomentLevel.ToString();
    }
}
