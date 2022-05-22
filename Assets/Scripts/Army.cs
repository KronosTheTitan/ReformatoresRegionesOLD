using System.Collections;
using System.Collections.Generic;
using GameWorld;
using UIHandeling;
using UnityEngine;
using UnityEngine.Serialization;

public class Army : MilitaryUnit
{
    public int infantry;
    public int cavalry;
    public int artillery;

    public int movementPoints = 2;

    [SerializeField] bool isDead;
    [SerializeField] bool isEmbarked;

    public Province location;
    Province _previousLocation;

    public Country owningCountry;

    int _siegeCounter;

    [SerializeField]
    ArmyMenu armyMenu;
    private void Start()
    {
        transform.position = location.armyPos.position;
        location.occupationArmy = this;
    }

    public bool TakeDamage(int damage, bool stage1)
    {
        if (stage1)
            for (int i = damage; i > 0; i--)
            {
                if (cavalry > 0)
                {
                    cavalry--;
                    owningCountry.manpowerGraveyard0++;
                }
                else
                {
                    break;
                }
                damage--;
            }
        for (int i = damage; i > 0; i--)
        {
            if (infantry >= artillery && infantry > 0)
            {
                infantry--;
                owningCountry.manpowerGraveyard0++;
            }
            else
            {
                if (artillery > 0)
                {
                    artillery--;
                    owningCountry.manpowerGraveyard0++;
                }
            }
            if (infantry + artillery <= 0)
            {
                Retreat(location);
                return true;
            }
            damage--;
        }
        return false;
    }
    public void Click()
    {
        if (owningCountry == GameManager.instance.activeCountry)
            armyMenu.OpenMenu();
    }
    public int InflictDamage(int attacksToMake)
    {
        int damage = 0;
        for (int i = attacksToMake; i > 0; i--)
            if (Random.Range(1, 100) < 67)
            {
                damage++;
            }
        return damage;
    }
    public void Siege()
    {
        if (isDead)
            return;
        if (location.owningCountry != owningCountry && owningCountry.atWarWith.Contains(location.owningCountry))
        {
            _siegeCounter++;
            if (_siegeCounter == location.develpomentLevel)
            {
                _siegeCounter = 0;
                location.ChangeOwner(owningCountry);
            }
        }
    }
    public override void Move(Province destination)
    {
        if (movementPoints <= 0) return;
        if (destination.landNeighbours.Contains(location))
        {
            if (destination.owningCountry != owningCountry)
            {
                if ((owningCountry.atWarWith.Contains(destination.owningCountry) || owningCountry.activeAlliances.Contains(destination.owningCountry)) && location.owningCountry == owningCountry)
                {
                    if (destination.occupationArmy != null)
                    {
                        if (owningCountry.atWarWith.Contains(destination.occupationArmy.owningCountry))
                        {
                            destination.ResolveBattle(this, destination.occupationArmy);
                        }
                    }
                    else
                    {
                        location.occupationArmy = null;
                        destination.occupationArmy = this;
                        location = destination;
                        transform.position = destination.armyPos.position;
                        movementPoints--;
                        _siegeCounter = 0;
                    }
                }
            }
            else
            {
                if (destination.occupationArmy != null)
                {
                    if (owningCountry.atWarWith.Contains(destination.occupationArmy.owningCountry))
                    {
                        destination.ResolveBattle(this, destination.occupationArmy);
                    }
                }
                else
                {
                    location.occupationArmy = null;
                    destination.occupationArmy = this;
                    location = destination;
                    transform.position = destination.armyPos.position;
                    movementPoints--;
                    _siegeCounter = 0;
                }
            }
        }
        else
        {
            if (destination.seaNeighbours.Contains(location) && (location.owningCountry == destination.owningCountry) && (location.owningCountry == owningCountry))
            {
                if (destination.occupationArmy != null)
                {
                    if (owningCountry.atWarWith.Contains(destination.occupationArmy.owningCountry))
                    {
                        destination.ResolveBattle(this, destination.occupationArmy);
                    }
                }
                else
                {
                    location.occupationArmy = null;
                    destination.occupationArmy = this;
                    location = destination;
                    transform.position = destination.armyPos.position;
                    movementPoints--;
                    _siegeCounter = 0;
                }
            }
        }
    }
    public void Retreat(Province start)
    {
        if (location != start) return;
        _siegeCounter = 0;
        List<Province> potentialRetreats = new List<Province>();
        foreach (Province province in start.landNeighbours)
        {
            if (province.occupationArmy == null)
            {
                if (owningCountry == province.owningCountry || owningCountry.activeAlliances.Contains(province.owningCountry))
                {
                    potentialRetreats.Add(province);
                }
            }
        }
        if (potentialRetreats.Count <= 0)
        {
            foreach (Province province in start.seaNeighbours)
            {
                if (owningCountry == province.owningCountry && province.occupationArmy == null)
                {
                    potentialRetreats.Add(province);
                }
            }
        }
        if (potentialRetreats.Count <= 0)
        {
            infantry = 0;
            cavalry = 0;
            artillery = 0;
            location.occupationArmy = null;
            isDead = true;
            gameObject.SetActive(false);
        }
        else
        {
            Province province = potentialRetreats[Random.Range(0, potentialRetreats.Count)];
            location.occupationArmy = null;
            province.occupationArmy = this;
            location = province;
            transform.position = province.armyPos.position;
        }
    }
    public void RaiseArmy(Province province)
    {
        if (isDead && province.occupationArmy == null && owningCountry.manpowerCurrent > 0)
        {
            isDead = false;
            location = province;
            owningCountry.manpowerCurrent--;
            infantry++;
            transform.position = province.armyPos.position;
            GameManager.ForceUIUpdate();
            gameObject.SetActive(true);
        }
    }

    public void Disband()
    {
        isDead = true;
        owningCountry.manpowerCurrent += infantry;
        infantry = 0;
        owningCountry.manpowerCurrent += cavalry;
        cavalry = 0;
        owningCountry.manpowerCurrent += artillery;
        artillery = 0;
        location.occupationArmy = null;
        armyMenu.CloseMenu();
        GameManager.ForceUIUpdate();
        gameObject.SetActive(false);
    }
    public void ArmyAI(List<Province> provinces)
    {

    }

    public bool CheckIfDead()
    {
        return isDead;
    }
    public void Embark()
    {
        
    }
}
