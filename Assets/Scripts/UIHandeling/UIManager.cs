using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image cornerFlag;
    [SerializeField]
    Text countryName;
    [SerializeField]
    Text treasury;
    [SerializeField]
    Text manpower;
    [SerializeField]
    Transform eventTarget;
    private void Start()
    {
        GameManager.UpdateAllUI += UpdateUI;
    }
    public void UpdateUI()
    {
        cornerFlag.sprite = GameManager.activeCountry.flag;
        countryName.text = GameManager.activeCountry.countryName;
        treasury.text = " "+GameManager.activeCountry.treasury.ToString();
        manpower.text = " " + GameManager.activeCountry.manpowerCurrent.ToString()+ " ("+GameManager.activeCountry.manpowerCap.ToString()+")";
        for (int i = 0; i < GameManager.activeCountry.eventQueue.Count; i++)
        {
            //Vector3 targetPos = new Vector3(eventTarget.position.x + (i * 74), eventTarget.position.y);
            //RectTransform rect = GameManager.activeCountry.eventQueue[i].eventBarItem.GetComponent<RectTransform>();
            //rect.localPosition = targetPos;
            Transform targetPos = eventTarget;
            float x = eventTarget.position.x + (i * 74);
            float y = eventTarget.position.y;
            
            Vector2 pos = GameManager.activeCountry.eventQueue[i].transform.position;
            pos.x = x;
            pos.y = y;
            
            GameManager.activeCountry.eventQueue[i].eventBarItem.transform.position = pos;
        }
    }
}
