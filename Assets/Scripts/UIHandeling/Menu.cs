using UnityEngine;

namespace UIHandeling
{
    public class Menu : MonoBehaviour
    {
        public Canvas menu;
        public virtual void OpenMenu()
        {
            if (GameManager.instance.openMenu != null)
                GameManager.instance.openMenu.CloseMenu();
            GameManager.instance.openMenu = this;
            menu.gameObject.SetActive(true);
        }
        public virtual void CloseMenu()
        {
            GameManager.instance.openMenu = null;
            menu.gameObject.SetActive(false);
        }
    }
}
