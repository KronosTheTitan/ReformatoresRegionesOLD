using UnityEngine;

namespace GameWorld
{
    public class Government : MonoBehaviour
    {
        string _rulerTitle;

        [SerializeField] protected Country country;
        public virtual void NewRuler(Culture culture)
        {
            if(country.ruler != null)
                Destroy(country.ruler.gameObject);
            GameObject rulerObject = new GameObject();
            rulerObject.transform.SetParent(country.gameObject.transform);
            rulerObject.name = "ruler : "+country.name;
            country.ruler = rulerObject.AddComponent<Ruler>();
            country.ruler.CreateRuler(country.culture);
        }

        public static void EstablishGovernment(Country country)
        {
            if(country.government != null)
                Destroy(country.government.gameObject);
        }
    }
}
