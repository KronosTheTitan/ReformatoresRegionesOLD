using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using GameWorld;
using UnityEngine;

public class War : MonoBehaviour
{
    public List<Country> attackers = new List<Country>();
    public Country attackerLeader;

    public List<Country> defenders = new List<Country>();
    public Country defenderLeader;

    private int turnsSinceBattle = 0;

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
            GameManager.instance.grandEmpire.emperor.activeWars.Add(this);
            defenders.Add(GameManager.instance.grandEmpire.emperor);
            foreach(Country country in GameManager.instance.grandEmpire.emperor.activeAlliances)
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

    private void Start()
    {
        GameManager.UpdateAllUI += UpdateUI;
    }

    private void UpdateUI(Country country)
    {
        if (country.activeWars.Contains(this))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void JoinWar(Country country)
    {

    }
    
    /// <summary>
    /// This method is used to end a war, it automatically updates the at war with list.
    /// </summary>
    public void EndWar()
    {
        foreach(Country country in attackers)
        {
            country.activeWars.Remove(this);
            country.UpdateAtWarWithList();
        }
        foreach(Country country1 in defenders)
        {
            country1.activeWars.Remove(this);
            country1.UpdateAtWarWithList();
        }
        GameManager.ForceUIUpdate();
        Destroy(gameObject);
    }
    public void SueForPeace()
    {
        if (turnsSinceBattle > 3)
        {
            EndWar();
        }
        else
        {
            if(GameManager.instance.activeCountry == attackerLeader)
                GameManager.instance.eventCardManager.SendPeaceOffer(defenderLeader,this);
            if(GameManager.instance.activeCountry == defenderLeader)
                GameManager.instance.eventCardManager.SendPeaceOffer(attackerLeader,this);
        }
    }
}
