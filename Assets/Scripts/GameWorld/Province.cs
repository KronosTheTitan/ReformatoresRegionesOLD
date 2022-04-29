using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Province : MonoBehaviour
{
    public Country owningCountry;
    public Army occupationArmy;
    public Transform armyPos;
    public Navy port;

    public int ID;

    public int develpomentLevel = 1;

    [SerializeField]
    public List<Province> landNeighbours = new List<Province>();
    [SerializeField]
    public List<Province> seaNeighbours = new List<Province>();
    [SerializeField]
    NavalRegion coast;

    public ProvinceUI provinceUI;

    [SerializeField]
    ProvinceDiploMenuUI provinceDiplo;

    [SerializeField]
    ProvinceMenuUI provinceMenu;

    private void Start()
    {
        GameManager.OnNextTurnProvince += OnNextTurn;
    }
    private void Update()
    {
        gameObject.name = "Province" + ID;
        provinceUI.UpdateProvinceBanner();
    }
    public void OnNextTurn()
    {
        if (GameManager.activeCountry != owningCountry)
            return;
        UpdateProvinceYield();
    }
    public virtual void ChangeOwner(Country newOwner)
    {
        owningCountry.ownedProvinces.Remove(this);
        if (owningCountry.capital == this)
        {

        }
        owningCountry = newOwner;
        provinceUI.UpdateProvinceBanner();
    }

    void UpdateProvinceYield()
    {
        int goldYield = develpomentLevel * 5;
        int manPower = develpomentLevel;
        owningCountry.manpowerCap += manPower;
        owningCountry.treasury += goldYield;
    }
    public void Click()
    {
        if(GameManager.selectedUnit != null)
        {
            GameManager.selectedUnit.Move(this);
        }
        else
        {
            if (GameManager.activeCountry == owningCountry)
            {
                provinceMenu.OpenMenu();
            }
            else
            {
                provinceDiplo.OpenMenu();
            }
        }
    }
    public void ResolveBattle(Army attacker,Army defender)
    {
        int aDam = 0;
        int dDam = 0;
        int aDamT = 0;
        int dDamT = 0;
        aDam = attacker.InflictDamage(attacker.cavalry);
        aDamT += aDam;
        dDam = defender.InflictDamage(defender.cavalry);
        dDamT += dDam;
        if (attacker.TakeDamage(dDam, true)) return;
        if (defender.TakeDamage(aDam, true)) return;
        aDam = attacker.InflictDamage(attacker.infantry + (defender.artillery)*2);
        aDamT += aDam;
        dDam = defender.InflictDamage(defender.infantry + (defender.artillery)*2);
        dDamT += dDam;
        if (attacker.TakeDamage(dDam, false)) return;
        if (defender.TakeDamage(aDam, false)) return;

        if(aDamT > dDamT)
        {
            defender.Retreat(this);
            attacker.movementPoints++;
            attacker.Move(this);
        }
        else
        {
            attacker.Retreat(this);
        }
        GameManager.ForceUIUpdate();
    }

    public void CreateNewArmy()
    {
        foreach (Army army in owningCountry.armies)
        {
            if (!army.CheckIfDead()) continue;
            army.RaiseArmy(this);
            return;
        }
    }
}
