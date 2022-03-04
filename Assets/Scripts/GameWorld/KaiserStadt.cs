using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaiserStadt : Province
{
    public override void ChangeOwner(Country newOwner)
    {
        if(newOwner.government is Government_Monarchy)
        {
            GameManager.grandEmpire.emperor = newOwner;
        }
        base.ChangeOwner(newOwner);
    }
}
