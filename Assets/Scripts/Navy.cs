using System.Collections;
using System.Collections.Generic;
using GameWorld;
using UnityEngine;

public class Navy : MilitaryUnit
{
    [SerializeField]
    bool isDocked;
    [SerializeField]
    NavalRegion navalRegion;
    [SerializeField]
    Province port;
    public Army embarkedArmy;
    void Dock(Province province)
    {
        if (!navalRegion.ports.Contains(province)) return;
        if(province.port != null) return;
        province.port = this;
        port = province;
        isDocked = true;
    }
    public void NavalMove(NavalRegion navalRegion)
    {

    }
}
