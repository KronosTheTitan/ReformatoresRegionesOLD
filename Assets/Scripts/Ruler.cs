using System.Collections;
using System.Collections.Generic;
using GameWorld;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    int _rulerSkill;
    string _rulerFirstName;
    string _rulerLastName;

    public string RulerLastName
    {
        get
        {
            return _rulerLastName;
        }
    }

    public string RulerName
    {
        get
        {
            return _rulerFirstName + " " + _rulerLastName;
        }
    }

    public int RulerSkill
    {
        get
        {
            return _rulerSkill;
        }
    }
    public void CreateRuler(Culture culture,Ruler previousRuler = null,bool titelIsInherited = false)
    {
        _rulerSkill = Random.Range(1, 12);
        _rulerFirstName = culture.rulerFirstNames[Random.Range(0,culture.rulerFirstNames.Length)];
        if (titelIsInherited && previousRuler)
            _rulerLastName = previousRuler.RulerLastName;
        else
            _rulerLastName = culture.rulerLastNames[Random.Range(0,culture.rulerLastNames.Length)];
    }
}
