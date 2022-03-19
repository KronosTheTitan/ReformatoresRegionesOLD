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
            Vector2 targetPos = new Vector2(eventTarget.position.x + (i * 74), eventTarget.position.y);
            GameManager.activeCountry.eventQueue[i].eventBarItem.gameObject.transform.position = targetPos;
        }
    }
}
