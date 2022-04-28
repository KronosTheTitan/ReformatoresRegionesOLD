using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (receiver.AIControlled)
        {

        }
        else
        {
            receiver.eventQueue.Remove(this);
            Destroy(gameObject);
            GameManager.ForceUIUpdate();
        }
    }
    public virtual void option1()
    {
        Close();
    }
    public virtual void option2()
    {

    }
    public void OnCreation()
    {

    }
    public virtual bool Allowed(Country country)
    {
        return true;
    }

    private void Update()
    {
        if (!menu.gameObject.activeSelf) return;
        if(Input.GetKeyDown(KeyCode.Alpha1)) option1();
        if(Input.GetKeyDown(KeyCode.Alpha2)) option2();
    }
}
