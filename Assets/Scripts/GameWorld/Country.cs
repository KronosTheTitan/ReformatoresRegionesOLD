using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Country : MonoBehaviour
{
    public string countryName;

    public int manpowerCap;
    public int manpowerCurrent;
    public int manpowerUsed;
    public int manpowerGraveyard0;
    int manpowerGraveyard1;
    int manpowerGraveyard2;

    public int treasury;

    public Culture culture;

    public Sprite flag;

    public List<Province> ownedProvinces;
    public Province capital;

    [SerializeField]
    public Army[] armies;
    Navy navy;

    public bool inEmpire;

    public List<War> activeWars;
    public List<Country> atWarWith;
    public List<Country> activeAlliances;

    Ruler ruler;
    public Government government;

    bool isVassal;
    Country overlord;

    List<Country> vassals;

    public bool AIControlled;

    [SerializeField]
    CountryAI countryAI;

    public List<EventCard> eventQueue;

    private void Start()
    {
        gameObject.name = countryName;
        GameManager.UpdateManpower += UpdateManpower;
    }

    public void OnNextTurn()
    {
        manpowerCap = 0;
        //government.newRuler(culture);
        foreach (Army army in armies)
        {
            army.Siege();
            army.movementPoints = 2;
        }
    }
    public void DeclareWarUpon(Country attacker)
    {
        GameObject warObject = new GameObject();
        War war = warObject.AddComponent(typeof (War)).GetComponent<War>();
        war.StartWar(attacker, this);
        GameManager.ForceUIUpdate();
    }
    void UpdateManpower()
    {
        if (GameManager.activeCountry != this) return;
        manpowerGraveyard2 = manpowerGraveyard1;
        manpowerGraveyard1 = manpowerGraveyard0;
        manpowerCurrent = manpowerCap - manpowerUsed - manpowerGraveyard1 - manpowerGraveyard2;
    }
    public void RunAI(GameManager gameManager)
    {
        if (ownedProvinces.Count <= 0)
        {
            gameManager.NextTurn();
        }
        if (!AIControlled) return;
        countryAI.AI(gameManager);
    }
    public void PickCapital()
    {
        List < Province > l3 = new List<Province>();
        List < Province > l2 = new List<Province>();
        List < Province > l1 = new List<Province>();
        foreach(Province province in ownedProvinces)
        {
            if (province.develpomentLevel == 3)
                l3.Add(province);
            if (province.develpomentLevel == 2)
                l2.Add(province);
            if (province.develpomentLevel == 1)
                l1.Add(province);
        }
        if (l3.Count >= 1)
            capital = l3[Random.Range(0, l3.Count)];
        else if (l2.Count >= 1)
            capital = l2[Random.Range(0, l2.Count)];
        else if (l1.Count >= 1)
            capital = l1[Random.Range(0, l1.Count)];
    }
    public int GetArmyWeight()
    {
        int output = 0;
        foreach (Army army in armies)
            output += army.infantry + army.cavalry + (army.artillery*2);
        return output;
    }
    public void UpdateWars()
    {
        atWarWith.Clear();
        foreach(War war in activeWars)
        {
            if (war.defenders.Contains(this))
                atWarWith.AddRange(war.attackers);
            else
                atWarWith.AddRange(war.defenders);
        }
    }
}
