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
    [SerializeField]
    Text infText;
    [SerializeField]
    Text cavText;
    [SerializeField]
    Text artText;
    [SerializeField]
    Image flag;
    public override void OpenMenu()
    {
        GameManager.selectedUnit = army;
        UpdateBanner();
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
        infText.text = army.infantry.ToString() + "K";
        cavText.text = army.cavalry.ToString() + "K";
        artText.text = army.artillery.ToString() + "K";
        flag.sprite = army.owningCountry.flag;
    }
    public void AddToArmy(int i)
    {
        if (GameManager.activeCountry.manpowerCurrent <= 0) return;
        if(i == 0)
        {
            GameManager.activeCountry.manpowerCurrent--;
            GameManager.activeCountry.manpowerUsed++;
            army.infantry++;
        }
        if (i == 1 && army.cavalry < 4)
        {
            GameManager.activeCountry.manpowerCurrent--;
            GameManager.activeCountry.manpowerUsed++;
            army.cavalry++;
        }
        if (i == 2 && army.infantry > army.artillery)
        {
            GameManager.activeCountry.manpowerCurrent--;
            GameManager.activeCountry.manpowerUsed++;
            army.artillery++;
        }
        UpdateBanner();
        GameManager.ForceUIUpdate();
    }
    public void RemoveFromArmy(int i)
    {
        if (i == 0 && army.infantry > 0)
        {
            GameManager.activeCountry.manpowerCurrent++;
            GameManager.activeCountry.manpowerUsed--;
            army.infantry--;
        }
        if (i == 1 && army.cavalry > 0)
        {
            GameManager.activeCountry.manpowerCurrent++;
            GameManager.activeCountry.manpowerUsed--;
            army.cavalry--;
        }
        if (i == 2 && army.artillery > 0)
        {
            GameManager.activeCountry.manpowerCurrent++;
            GameManager.activeCountry.manpowerUsed--;
            army.artillery--;
        }
        UpdateBanner();
        GameManager.ForceUIUpdate();
    }
}
