using System.Collections.Generic;
using EventSystem;
using GameWorld;
using UnityEngine;

namespace AI_Country
{
    public class CountryAI : MonoBehaviour
    {
        public Country country;
        public List<Country> landNeighbours = new List<Country>();
        public List<Country> seaNeighbours = new List<Country>();

        List<Province> _potentialMoves = new List<Province>();
        public void RunAI()
        {
            foreach(EventCard eventCard in country.eventQueue)
            {
                eventCard.EvaluateAI();
            }
            _potentialMoves.Clear();
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
            foreach(Army army in country.armies)
            {
                army.ArmyAI(_potentialMoves);
            }
        }
    }
}
