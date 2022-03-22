using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestJoinWar : EventCard
{
    public War war;
    public Side side;
    public enum Side
    {
        ATTACKER,
        DEFENDER
    }
    public override void EvaluateAI()
    {
        if (side == Side.ATTACKER)
        {

        }
    }
    public override void option1()
    {
        base.option1();
    }
    public override void option2()
    {
        if(side == Side.ATTACKER)
        {
            war.attackers.Add(receiver);
            receiver.activeWars.Add(war);
        }
    }
}
