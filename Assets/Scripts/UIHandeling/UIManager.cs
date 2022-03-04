using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image cornerFlag;
    [SerializeField]
    Text countryName;
    [SerializeField]
    Text treasury;
    [SerializeField]
    Text manpower;
    [SerializeField]
    private void Start()
    {
        GameManager.UpdateAllUI += UpdateUI;
    }
    public void UpdateUI()
    {
        cornerFlag.sprite = GameManager.activeCountry.flag;
        countryName.text = GameManager.activeCountry.countryName;
        treasury.text = " "+GameManager.activeCountry.treasury.ToString();
        manpower.text = " " + GameManager.activeCountry.manpowerCurrent.ToString();
    }
}
