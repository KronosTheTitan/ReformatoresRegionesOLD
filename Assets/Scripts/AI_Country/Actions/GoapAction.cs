using UnityEngine;

namespace AI_Country.Actions
{
    public class GoapAction : MonoBehaviour
    {
        public float cost;

        public CountryAI countryAI;

        public virtual bool PreCondition()
        {
            return true;
        }

        public virtual float CalculateCost()
        {
            return 0;
        }

        public virtual void ExecuteAction()
        {
            
        }
    }
}
