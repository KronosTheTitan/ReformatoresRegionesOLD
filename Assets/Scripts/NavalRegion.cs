using System.Collections;
using System.Collections.Generic;
using GameWorld;
using UIHandeling;
using UnityEngine;

public class NavalRegion : MonoBehaviour
{
    public List<Province> ports;

    [SerializeField]
    List<NavalRegion> seaRoutes;

    [SerializeField]
    NavalRegionMenu navalMenu; 

    List<Navy> _navies;

    public void Click()
    {
        if(GameManager.instance.selectedUnit != null)
        {
            if(GameManager.instance.selectedUnit is Navy)
            {
                Navy navy = (Navy)GameManager.instance.selectedUnit;
                navy.NavalMove(this);
            }
        }
        else
        {
            navalMenu.OpenMenu();
        }
    }
}
