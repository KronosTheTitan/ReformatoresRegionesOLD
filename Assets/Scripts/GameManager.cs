using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Province[] provinces;
    public static GrandEmpire grandEmpire;

    public static MilitaryUnit selectedUnit;

    [SerializeField]
    Country[] countries;

    [SerializeReference]
    GrandEmpire initEmpire;

    public static Country activeCountry;
    public static Menu openMenu;

    int currentCountry = 0;

    int round;

    [SerializeField]
    int maxRounds = 50;

    [SerializeField]
    UIManager UIManager;

    private void Start()
    {
        activeCountry = countries[currentCountry];
        foreach (Province province in provinces)
        {
            province.provinceUI.UpdateProvinceBanner();
            UpdateAllUI += province.provinceUI.UpdateProvinceBanner;
        }
        grandEmpire = initEmpire;
    }

    public void NextTurn()
    {
        if (openMenu != null)
            openMenu.CloseMenu();
        ChangeCountry();
        activeCountry.OnNextTurn();
        OnNextTurnProvince();
        UpdateAllUI();
        UpdateManpower();
        activeCountry.RunAI(this);
    }
    void ChangeCountry()
    {
        currentCountry++;
        if (currentCountry > countries.Length - 1)
        {
            currentCountry = 0;
            if (round == maxRounds)
                round++;
        }
        activeCountry = countries[currentCountry];
    }
    public static void ForceUIUpdate()
    {
        UpdateAllUI();
    }
    public delegate void UpdateUIDelegate();
    public static event UpdateUIDelegate UpdateAllUI;

    public delegate void NextTurnProvinceDelegate();
    public static event UpdateUIDelegate OnNextTurnProvince;

    public delegate void UpdateManpowerDelegate();
    public static event UpdateUIDelegate UpdateManpower;
}
