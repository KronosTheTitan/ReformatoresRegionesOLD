using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Canvas menu;
    public virtual void OpenMenu()
    {
        if (GameManager.openMenu != null)
            GameManager.openMenu.CloseMenu();
        GameManager.openMenu = this;
        menu.gameObject.SetActive(true);
    }
    public virtual void CloseMenu()
    {
        GameManager.openMenu = null;
        menu.gameObject.SetActive(false);
    }
}
