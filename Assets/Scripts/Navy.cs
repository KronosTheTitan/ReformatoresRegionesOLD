using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navy : MilitaryUnit
{
    [SerializeField]
    bool _isDocked;
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
        _isDocked = true;
    }
    public void NavalMove(NavalRegion navalRegion)
    {

    }
}
