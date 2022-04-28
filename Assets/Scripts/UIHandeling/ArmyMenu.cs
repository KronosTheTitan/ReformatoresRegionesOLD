using System;
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
    Sprite bannerAtWar;
    [SerializeField]
    Sprite bannerAtPeace;
    [SerializeField]
    Sprite bannerAllied;
    [SerializeField]
    Sprite bannerOwned;
    
    [SerializeField]
    Image flag;
    
    [SerializeField]
    Image bannerImage;
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
        
        bannerFlag.sprite = army.owningCountry.flag;
        if (army.owningCountry == GameManager.activeCountry)
        {
            bannerImage.sprite = bannerOwned;
        }
        else
        {
            bannerImage.sprite = bannerAtPeace;
        }
        if(GameManager.activeCountry.activeAlliances.Count != 0)
            if (GameManager.activeCountry.activeAlliances.Contains(army.owningCountry))
            {
                bannerImage.sprite = bannerAllied;
            }
        if (GameManager.activeCountry.atWarWith.Count != 0)
            if (GameManager.activeCountry.atWarWith.Contains(army.owningCountry))
            {
                bannerImage.sprite = bannerAtWar;
            }
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
        GameManager.ForceUIUpdate();
    }

    public void Update()
    {

        if (Vector3.Distance(banner.transform.position, Camera.main.transform.position) > 750 || CameraController.Instance.transform.position.y == CameraController.Instance.maxY)
        {
            banner.gameObject.SetActive(false);
        }
        else
        {
            banner.gameObject.SetActive(true);
            float x = Camera.main.transform.rotation.x-banner.transform.rotation.x;
            banner.transform.Rotate(x,0,0);
        }
    }
}
