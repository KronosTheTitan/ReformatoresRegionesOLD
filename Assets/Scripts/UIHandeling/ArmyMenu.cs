using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyMenu : Menu
{
    [SerializeField]
    Army army;
    [SerializeField]
    Canvas banner;
    [SerializeField]
    Text bannerTotal;
    [SerializeField]
    Image bannerFlag;


    public override void OpenMenu()
    {
        GameManager.selectedUnit = army;
        base.OpenMenu();
    }

    public override void CloseMenu()
    {
        GameManager.selectedUnit = null;
        base.CloseMenu();
    }
    public void UpdateBanner()
    {
        bannerTotal.text = (army.infantry + army.cavalry + army.artillery).ToString() + "K";
        bannerFlag.sprite = army.owningCountry.flag;
    }
}
