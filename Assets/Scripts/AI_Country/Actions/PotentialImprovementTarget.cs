using GameWorld;

namespace AI_Country.Actions
{
    public class PotentialImprovementTarget
    {
        private float weight = 0;
        public Province province;

        public PotentialImprovementTarget(Province pProvince)
        {
            province = pProvince;
            weight += province.develpomentLevel;
        }
    }
}