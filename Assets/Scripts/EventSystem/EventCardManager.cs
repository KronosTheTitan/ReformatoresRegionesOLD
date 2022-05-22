using System;
using System.Collections.Generic;
using GameWorld;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EventSystem
{
    public class EventCardManager : MonoBehaviour
    {
        [SerializeField] private List<EventCard> events;

        [SerializeField] private PeaceOffer _peaceOffer;
        
        public void AddNewEventCardToCountry(Country country)
        {
            List<EventCard> potentialEvents = new List<EventCard>();
            foreach (EventCard eventCard in events)
                if (eventCard.Allowed(country))
                    potentialEvents.Add(eventCard);
            EventCard selected = potentialEvents[Random.Range(0, potentialEvents.Count)];
            GameObject newGameObject = Instantiate(selected.gameObject);
            selected = newGameObject.GetComponent<EventCard>();
            selected.receiver = country;
            country.eventQueue.Add(selected);
        }

        public void SendPeaceOffer(Country country, War war)
        {
            
        }
    }
}
