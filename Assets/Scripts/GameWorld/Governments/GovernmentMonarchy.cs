using UnityEngine;

namespace GameWorld.Governments
{
    public class GovernmentMonarchy : Government
    {
        public override void NewRuler(Culture culture)
        {
            int number = Random.Range(1, 6) + Random.Range(1, 6);
            if(number!=7 && country.ruler != null) return;
            Ruler previousRuler = country.ruler;
            if(country.ruler != null)
                Destroy(country.ruler.gameObject);
            GameObject rulerObject = new GameObject();
            rulerObject.transform.SetParent(country.gameObject.transform);
            rulerObject.name = "ruler : "+country.name;
            country.ruler = rulerObject.AddComponent<Ruler>();
            country.ruler.CreateRuler(country.culture,previousRuler,true);
        }
    }
}
