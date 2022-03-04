using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceDiploMenuUI : Menu
{
    [SerializeField]
    Image flag;
    [SerializeField]
    Province province;
    [SerializeField]
    Text topBarName;

    public override void OpenMenu()
    {
        base.OpenMenu();
        UpdateMenu();
    }
    void UpdateMenu()
    {
        flag.sprite = province.owningCountry.flag;
        topBarName.text = province.owningCountry.countryName;
    }
    public void DeclareWarButton()
    {
        province.owningCountry.DeclareWarUpon(GameManager.activeCountry);
    }
    public void ProposePeaceButton()
    {
        if(GameManager.activeCountry.activeWars.Count > 0)
        {
            foreach(War war in GameManager.activeCountry.activeWars)
            {
                if(war.attackerLeader == province.owningCountry || war.defenderLeader == province.owningCountry)
                {
                    war.SueForPeace();
                }
            }
        }
    }
    public void ProposeAllianceButton()
    {

    }
}
