namespace AI_Country.Actions
{
    public class ActionDeclareWar : GoapAction
    {
        public override bool PreCondition()
        {
            if (countryAI.landNeighbours.Count == 0 && countryAI.seaNeighbours.Count == 0) return false;

            if (countryAI.country.atWarWith.Count > 0) return false;

            return true;
        }
    }
}