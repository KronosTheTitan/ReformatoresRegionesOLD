using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : MonoBehaviour
{
    public Country receiver;
    public virtual void EvaluateAI()
    {

    }
    public void Open()
    {

    }
    public void Close()
    {
        if (receiver.AIControlled)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public virtual void option1()
    {

    }
    public virtual void option2()
    {

    }
}
