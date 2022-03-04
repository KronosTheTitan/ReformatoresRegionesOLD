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

    bool inEmpire;

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
        if (inEmpire)
        {

        }
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
}
