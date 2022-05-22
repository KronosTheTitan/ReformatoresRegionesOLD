using GameWorld;
using UnityEngine;

namespace EventSystem
{
    public class EventCard : MonoBehaviour
    {
        public Country receiver;

        public Canvas eventBarItem;

        [SerializeField]
        Canvas menu;
        public virtual void EvaluateAI()
        {

        }
        public void Open()
        {
            menu.gameObject.SetActive(true);
        }
        public void Close()
        {
            if (receiver.aiControlled)
            {

            }
            else
            {
                receiver.eventQueue.Remove(this);
                Destroy(gameObject);
                GameManager.ForceUIUpdate();
            }
        }
        public virtual void Option1()
        {
            Close();
        }
        public virtual void Option2()
        {

        }
        public virtual bool Allowed(Country country)
        {
            return true;
        }

        private void Update()
        {
            if (!menu.gameObject.activeSelf) return;
            if(Input.GetKeyDown(KeyCode.Alpha1)) Option1();
            if(Input.GetKeyDown(KeyCode.Alpha2)) Option2();
        }
    }
}
