using GameWorld;

namespace AI_Country.Actions
{
    class GoapImproveProvince : GoapAction
    {
        private Province _selectedProvince;
        public override bool PreCondition()
        {
            foreach (Province province in countryAI.country.ownedProvinces)
            {
                if (province.develpomentLevel < 3)
                {
                    
                    
                }
            }
            return true;
        }

        public override float CalculateCost()
        {
            float pCost = 0;
            if (countryAI.country.atWarWith.Count > 0) pCost += 50;
            pCost += _selectedProvince.develpomentLevel * GameManager.instance.priceList.ImprovementCostPerLevel;
            return pCost;
        }

        public override void ExecuteAction()
        {
            _selectedProvince.IncreaseDevelopment();
        }
    }
}