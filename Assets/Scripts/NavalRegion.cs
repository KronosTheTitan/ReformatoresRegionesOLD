using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavalRegion : MonoBehaviour
{
    public List<Province> ports;

    [SerializeField]
    List<NavalRegion> seaRoutes;

    [SerializeField]
    NavalRegionMenu navalMenu; 

    List<Navy> navies;

    public void Click()
    {
        if(GameManager.selectedUnit != null)
        {
            if(GameManager.selectedUnit is Navy)
            {
                Navy navy = (Navy)GameManager.selectedUnit;
                navy.NavalMove(this);
            }
        }
        else
        {
            navalMenu.OpenMenu();
        }
    }
}
