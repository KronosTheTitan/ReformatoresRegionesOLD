using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard_1 : EventCard
{
    [SerializeField]
    int goldYield = 30;

    public override void option1()
    {
        receiver.treasury += goldYield;
        base.option1();
    }
}
