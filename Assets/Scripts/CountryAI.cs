using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryAI : MonoBehaviour
{
    public Country country;
    List<Country> landNeighbours = new List<Country>();
    List<Country> seaNeighbours = new List<Country>();

    List<Province> potentialMoves = new List<Province>();
    public void AI(GameManager gameManager)
    {
        potentialMoves.Clear();
        foreach(Province province in country.ownedProvinces)
        {
            foreach(Province province1 in province.landNeighbours)
            {
                if(!landNeighbours.Contains(province1.owningCountry)&&province1.owningCountry != country)
                {
                    landNeighbours.Add(province1.owningCountry); 
                }
            }
        }
        DeclareWar();
        foreach(Army army in country.armies)
        {
            army.ArmyAI(potentialMoves);
        }
        gameManager.NextTurn();
        foreach(EventCard eventCard in country.eventQueue)
        {
            eventCard.EvaluateAI();
        }
    }
    void DeclareWar()
    {
        if (country.activeWars.Count >= 1) return;
        foreach(Country neighbour in landNeighbours)
        {
            if (neighbour.inEmpire && !country.inEmpire)
            {
                int opposingStrength = 0;
                foreach (Country country1 in neighbour.activeAlliances)
                    opposingStrength += country1.GetArmyWeight();
                foreach (Country country1 in GameManager.grandEmpire.emperor.activeAlliances)
                    opposingStrength += country1.GetArmyWeight();
                if(opposingStrength > country.GetArmyWeight())
                {
                    neighbour.DeclareWarUpon(country);
                }
            }
            else
            {
                int opposingStrength = 0;
                foreach (Country country1 in neighbour.activeAlliances)
                    opposingStrength += country1.GetArmyWeight();;
                if (opposingStrength > country.GetArmyWeight())
                {
                    neighbour.DeclareWarUpon(country);
                }

            }
        }
    }
}
