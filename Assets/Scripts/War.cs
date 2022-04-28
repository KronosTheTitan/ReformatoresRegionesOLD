using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class War : MonoBehaviour
{
    public List<Country> attackers = new List<Country>();
    public Country attackerLeader;

    public List<Country> defenders = new List<Country>();
    public Country defenderLeader;

    public void StartWar(Country attacker,Country defender)
    {
        defenders.Add(defender);
        defenderLeader = defender;
        attackers.Add(attacker);
        attackerLeader = attacker;
        foreach(Country country in defender.activeAlliances)
        {
            if (!country.atWarWith.Contains(attacker))
            {
                country.activeWars.Add(this);
                defenders.Add(country);
            }
        }
        if (defender.inEmpire && !attacker.inEmpire)
        {
            GameManager.grandEmpire.emperor.activeWars.Add(this);
            defenders.Add(GameManager.grandEmpire.emperor);
            foreach(Country country in GameManager.grandEmpire.emperor.activeAlliances)
            {
                if (!country.atWarWith.Contains(attacker))
                {
                    country.activeWars.Add(this);
                    defenders.Add(country);
                }
            }
        }
        foreach(Country country1 in attackers)
        {
            foreach(Country country in defenders)
            {
                country.atWarWith.Add(country1);
                country1.atWarWith.Add(country);
            }
        }
    }
    public void JoinWar(Country country)
    {

    }
    public void EndWar()
    {
        foreach(Country country in attackers)
        {
            country.activeWars.Remove(this);
            country.UpdateWars();
        }
        foreach(Country country1 in defenders)
        {
            country1.activeWars.Remove(this);
            country1.UpdateWars();
        }
        GameManager.ForceUIUpdate();
        Destroy(gameObject);
    }
    public void SueForPeace()
    {

    }
}