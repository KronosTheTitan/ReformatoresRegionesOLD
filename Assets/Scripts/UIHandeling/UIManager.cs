using System;
using GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace UIHandeling
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image cornerFlagText;

        [SerializeField] private Text countryNameText;

        [SerializeField] private Text treasuryText;

        [SerializeField] private Text manpowerText;

        [SerializeField] private Text rulerNameText;

        [SerializeField] private Text rulerSkillText;

        [SerializeField] private Text rulerSkillStoredText;

        [SerializeField] private Transform eventTargetTransform;
        private void Start()
        {
            GameManager.UpdateAllUI += UpdateUI;
        }
        public void UpdateUI(Country activeCountry)
        {
            cornerFlagText.sprite = activeCountry.flag;
            countryNameText.text = activeCountry.countryName;
            treasuryText.text = " "+activeCountry.treasury.ToString();
            manpowerText.text = " " + activeCountry.manpowerCurrent.ToString()+ " ("+activeCountry.manpowerCap.ToString()+")";
            UpdateEventBar(activeCountry);
            UpdateRulerInfoTopBar(activeCountry);
        }
        /// <summary>
        /// update all the events in the queue for the passed in country displayed in the top bar.
        /// </summary>
        /// <param name="activeCountry"></param>
        void UpdateEventBar(Country activeCountry)
        {
            for (int i = 0; i < activeCountry.eventQueue.Count; i++)
            {
                //set the of the event bar item to the 
                activeCountry.eventQueue[i].transform.parent = transform;
                
                //calculate the position for the selected event in the top bar.
                float x = eventTargetTransform.position.x + (i * 72);
                float y = eventTargetTransform.position.y;
            
                Vector2 pos = activeCountry.eventQueue[i].transform.position;
                pos.x = x;
                pos.y = y;
            
                activeCountry.eventQueue[i].eventBarItem.transform.position = pos;
                Console.WriteLine(activeCountry.eventQueue[i].transform.parent.name);
            }
        }
        /// <summary>
        /// Update the information on the passed in countries ruler displayed in the top bar.
        /// </summary>
        /// <param name="activeCountry"></param>
        void UpdateRulerInfoTopBar(Country activeCountry)
        {
            rulerNameText.text = activeCountry.ruler.RulerName;
            
            rulerSkillText.text = "+"+activeCountry.ruler.RulerSkill.ToString();
            
            rulerSkillStoredText.text = "Skill points = \r\n"+activeCountry.rulerSkillStored;
        }
    }
}
