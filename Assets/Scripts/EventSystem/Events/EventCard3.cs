using GameWorld;
using GameWorld.Governments;
using UnityEngine;

namespace EventSystem.Events
{
    public class EventCard3 : EventCard
    {
        [SerializeField] private int goldYield = -30;

        public override void Option1()
        {
            int number = Random.Range(0, 1);
            if (number == 1)
            {
                
            }
            else
            {
                return;
            }
        }

        public override bool Allowed(Country country)
        {
            if (!(country.government is GovernmentMonarchy)) return false;
            return true;
        }
    }
}
