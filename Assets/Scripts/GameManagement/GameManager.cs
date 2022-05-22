using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using GameWorld;
using UIHandeling;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then 1 instance of GameManager found!");
            return;
        }
        instance = this;
    }

    [SerializeField] private Province[] provinces;
    public GrandEmpire grandEmpire;

    public PriceList priceList;

    public MilitaryUnit selectedUnit;

    public EventCardManager eventCardManager;

    public PrefabContainer prefabContainer;

    [SerializeField]
    Country[] countries;

    [SerializeReference]
    GrandEmpire initEmpire;

    public Country activeCountry;
    
    public Menu openMenu;

    int _currentCountry = 0;

    int _round;

    [SerializeField]
    int maxRounds = 50;

    [SerializeField]
    UIManager uiManager;

    private void Start()
    {
        activeCountry = countries[_currentCountry];
        foreach (Province province in provinces)
        {
            province.provinceUI.UpdateProvinceBanner(activeCountry);
            UpdateAllUI += province.provinceUI.UpdateProvinceBanner;
        }
        grandEmpire = initEmpire;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) NextTurn();
    }

    public void NextTurn()
    {
        if(activeCountry.eventQueue.Count>0) return;
        if (openMenu != null)
            openMenu.CloseMenu();
        ChangeCountry();
        activeCountry.OnNextTurn();
        eventCardManager.AddNewEventCardToCountry(activeCountry);
        eventCardManager.AddNewEventCardToCountry(activeCountry);
        UpdateAllUI(activeCountry);
        activeCountry.RunAI(this);
    }
    void ChangeCountry()
    {
        _currentCountry++;
        if (_currentCountry > countries.Length - 1)
        {
            _currentCountry = 0;
            if (_round == maxRounds)
                _round++;
        }
        activeCountry = countries[_currentCountry];
    }
    public static void ForceUIUpdate()
    {
        UpdateAllUI(instance.activeCountry);
    }
    public delegate void UpdateUIDelegate(Country activeCountry);
    public static event UpdateUIDelegate UpdateAllUI;
}
