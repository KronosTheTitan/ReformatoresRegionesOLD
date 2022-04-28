using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCardManager : MonoBehaviour
{
    [SerializeField]
    List<EventCard> events;

   
    // Start is called before the first frame update
    public void GetEvent(Country country)
    {
        List<EventCard> potentialEvents = new List<EventCard>();
        foreach (EventCard eventCard in events)
            if (eventCard.Allowed(country))
                potentialEvents.Add(eventCard);
        EventCard selected = potentialEvents[Random.Range(0, potentialEvents.Count)];
        GameObject gameObject = Instantiate(selected.gameObject);
        selected = gameObject.GetComponent<EventCard>();
        selected.receiver = country;
        selected.OnCreation();
        country.eventQueue.Add(selected);
    }
}
