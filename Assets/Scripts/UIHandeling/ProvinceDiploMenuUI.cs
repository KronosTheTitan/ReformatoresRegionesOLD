using GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace UIHandeling
{
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
            province.owningCountry.DeclareWarUpon(GameManager.instance.activeCountry);
        }
        public void ProposePeaceButton()
        {
            if(GameManager.instance.activeCountry.activeWars.Count > 0)
            {
                foreach(War war in GameManager.instance.activeCountry.activeWars)
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
}
