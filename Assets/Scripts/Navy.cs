using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navy : MilitaryUnit
{
    [SerializeField]
    bool docked;
    [SerializeField]
    NavalRegion navalRegion;
    [SerializeField]
    Province port;
    public Army embarkedArmy;
    void Dock(Province province)
    {
        if (!navalRegion.ports.Contains(province)) return;
    }
    public void NavalMove(NavalRegion navalRegion)
    {

    }
    public void EmbarkArmy()
    {
        if (!docked || port == null || embarkedArmy != null) return;
        if (port.occupationArmy == null) return;
        if (port.occupationArmy.owningCountry != GameManager.activeCountry) return;
        embarkedArmy = port.occupationArmy;
        embarkedArmy.embarked = true;
        embarkedArmy.location = null;
    }
}
