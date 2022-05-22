using UnityEngine;

namespace GameWorld.Governments
{
    public class GovernmentRepublic : Government
    {
        private int turnsSinceElection = 0;
        [SerializeField] private int electionTurnInterval;
        public override void NewRuler(Culture culture)
        {
            turnsSinceElection++;
            if(turnsSinceElection==2 && country.ruler != null) return;
            if(country.ruler != null)
                Destroy(country.ruler.gameObject);
            GameObject rulerObject = new GameObject();
            rulerObject.transform.SetParent(country.gameObject.transform);
            rulerObject.name = "ruler : "+country.name;
            country.ruler = rulerObject.AddComponent<Ruler>();
            country.ruler.CreateRuler(country.culture);
        }
    }
}
