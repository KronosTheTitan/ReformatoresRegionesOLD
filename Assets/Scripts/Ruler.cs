using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : ScriptableObject
{
    int rulerSkill;
    string rulerName;
    string lastName;
    public Ruler(Culture culture)
    {
        rulerSkill = Random.Range(1, 12);
        rulerName = culture.rulerFirstNames[Random.Range(0, culture.rulerLastNames.Length)] + " " + culture.rulerLastNames[Random.Range(0, culture.rulerLastNames.Length)];
    }
}
