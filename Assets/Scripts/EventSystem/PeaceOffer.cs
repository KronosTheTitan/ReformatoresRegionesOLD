using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceOffer : EventCard
{
    War war;

    public override void option1()
    {
        base.option1();
    }
    public override void option2()
    {
        foreach(Country country in war.attackers)
        {
            foreach(Country country1 in country.atWarWith)
            {
                if (war.defenders.Contains(country1))
                {
                    country.atWarWith.Remove(country1);
                }
            }
        }
        foreach(Country country2 in war.defenders)
        {
            foreach(Country country in country2.atWarWith)
            {
                if (war.attackers.Contains(country))
                {
                    country2.atWarWith.Remove(country2);
                }
            }
        }
    }
}
