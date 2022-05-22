using System.Collections.Generic;
using AI_Country.Actions;
using GameWorld;

namespace AI_Country.Goals
{
    public class GoalPrepareForWar : GoapGoal
    {
        public GoalPrepareForWar(CountryAI pCountryAI,Country warTarget) : base(pCountryAI)
        {
            _preparationTarget = warTarget;
        }
        
        private readonly Country _preparationTarget;
        public override GoapAction CheckSuccess()
        {
            bool anyArmyInPosition = false;

            List<Province> borderProvinces = new List<Province>();

            foreach (Province province in countryAI.country.ownedProvinces)
            {
                foreach (Province province1 in province.landNeighbours)
                {
                    if (province1.owningCountry == _preparationTarget)
                    {
                        if (province.occupationArmy != null)
                        {
                            if (province.occupationArmy.owningCountry == countryAI.country)
                            { 
                                anyArmyInPosition = true;
                            }
                        }
                        else
                        {
                            borderProvinces.Add(province);
                        }
                    }
                }
            }

            if (!anyArmyInPosition) return null;
            return null;
        }
    }
}