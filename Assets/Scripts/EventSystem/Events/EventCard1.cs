using UnityEngine;

namespace EventSystem.Events
{
    public class EventCard1 : EventCard
    {
        [SerializeField] private int goldYield = 30;

        public override void Option1()
        {
            receiver.treasury += goldYield;
            base.Option1();
        }
    }
}
