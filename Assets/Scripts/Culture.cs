using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Culture", menuName = "Cultures/Culture")]
public class Culture : ScriptableObject
{
    public string[] rulerFirstNames;
    public string[] rulerLastNames;

    public string[] provinceNames;
}
