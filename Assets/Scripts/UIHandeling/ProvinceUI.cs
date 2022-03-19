using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceUI : MonoBehaviour
{
    [SerializeField]
    Province province;

    [SerializeField]
    Canvas banner;

    [SerializeField]
    Image bannerImage;

    [SerializeField]
    Image bannerFlag;

    [SerializeField]
    Text nameText;

    [SerializeField]
    Sprite bannerAtWar;
    [SerializeField]
    Sprite bannerAtPeace;
    [SerializeField]
    Sprite bannerAllied;
    [SerializeField]
    Sprite bannerOwned;
    [SerializeField]
    Image cappitalImage;

    public void UpdateProvinceBanner()
    {
        nameText.text = province.owningCountry.culture.provinceNames[province.ID];
        bannerFlag.sprite = province.owningCountry.flag;
        if (province.owningCountry == GameManager.activeCountry)
        {
            bannerImage.sprite = bannerOwned;
        }
        else
        {
            bannerImage.sprite = bannerAtPeace;
        }
        if(GameManager.activeCountry.activeAlliances.Count != 0)
            if (GameManager.activeCountry.activeAlliances.Contains(province.owningCountry))
            {
                bannerImage.sprite = bannerAllied;
            }
        if (GameManager.activeCountry.atWarWith.Count != 0)
            if (GameManager.activeCountry.atWarWith.Contains(province.owningCountry))
            {
                bannerImage.sprite = bannerAtWar;
            }
        if (province.owningCountry.capital == province)
            cappitalImage.gameObject.SetActive(true);
        else
            cappitalImage.gameObject.SetActive(false);
    }
}
