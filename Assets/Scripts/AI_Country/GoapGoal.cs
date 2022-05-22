using AI_Country.Actions;
using UnityEngine;

namespace AI_Country
{
    public class GoapGoal
    {
        public GoapGoal(CountryAI pCountryAI)
        {
            countryAI = pCountryAI;
        }
        protected CountryAI countryAI;
        public virtual GoapAction CheckSuccess()
        {
            return null;
        }

        public virtual bool CancelCondition()
        {
            return true;
        }
    }
}
