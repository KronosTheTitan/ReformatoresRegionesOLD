using GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace UIHandeling
{
    public class ArmyMenu : Menu
    {
        [SerializeField]
        Army army;
        [SerializeField]
        Canvas banner;
        [SerializeField]
        Text bannerTotal;
        [SerializeField]
        Image bannerFlag;
        [SerializeField]
        Text infText;
        [SerializeField]
        Text cavText;
        [SerializeField]
        Text artText;
    
        [SerializeField]
        Sprite bannerAtWar;
        [SerializeField]
        Sprite bannerAtPeace;
        [SerializeField]
        Sprite bannerAllied;
        [SerializeField]
        Sprite bannerOwned;
    
        [SerializeField]
        Image flag;
    
        [SerializeField]
        Image bannerImage;
        public override void OpenMenu()
        {
            GameManager.instance.selectedUnit = army;
            UpdateBanner(GameManager.instance.activeCountry);
            base.OpenMenu();
        }

        private void Start()
        {
            GameManager.UpdateAllUI += UpdateBanner;
        }

        public override void CloseMenu()
        {
            GameManager.instance.selectedUnit = null;
            base.CloseMenu();
        }
        public void UpdateBanner(Country activeCountry)
        {
            bannerTotal.text = (army.infantry + army.cavalry + army.artillery).ToString() + "K";
            bannerFlag.sprite = army.owningCountry.flag;
            infText.text = army.infantry.ToString() + "K";
            cavText.text = army.cavalry.ToString() + "K";
            artText.text = army.artillery.ToString() + "K";
            flag.sprite = army.owningCountry.flag;
        
            bannerFlag.sprite = army.owningCountry.flag;
            if (army.owningCountry == activeCountry)
            {
                bannerImage.sprite = bannerOwned;
            }
            else
            {
                bannerImage.sprite = bannerAtPeace;
            }
            if(activeCountry.activeAlliances.Count != 0)
                if (activeCountry.activeAlliances.Contains(army.owningCountry))
                {
                    bannerImage.sprite = bannerAllied;
                }
            if (activeCountry.atWarWith.Count != 0)
                if (activeCountry.atWarWith.Contains(army.owningCountry))
                {
                    bannerImage.sprite = bannerAtWar;
                }
        }
        public void AddToArmy(int i)
        {
            if (army.owningCountry.manpowerCurrent <= 0) return;
            if(i == 0)
            {
                army.owningCountry.manpowerCurrent--;
                army.owningCountry.manpowerUsed++;
                army.infantry++;
            }
            if (i == 1 && army.cavalry < 4)
            {
                army.owningCountry.manpowerCurrent--;
                army.owningCountry.manpowerUsed++;
                army.cavalry++;
            }
            if (i == 2 && army.infantry > army.artillery)
            {
                army.owningCountry.manpowerCurrent--;
                army.owningCountry.manpowerUsed++;
                army.artillery++;
            }
            GameManager.ForceUIUpdate();
        }
        public void RemoveFromArmy(int i)
        {
            if (i == 0 && army.infantry > 0)
            {
                army.owningCountry.manpowerCurrent++;
                army.owningCountry.manpowerUsed--;
                army.infantry--;
            }
            if (i == 1 && army.cavalry > 0)
            {
                army.owningCountry.manpowerCurrent++;
                army.owningCountry.manpowerUsed--;
                army.cavalry--;
            }
            if (i == 2 && army.artillery > 0)
            {
                army.owningCountry.manpowerCurrent++;
                army.owningCountry.manpowerUsed--;
                army.artillery--;
            }
            GameManager.ForceUIUpdate();
        }

        public void Update()
        {

            if (Vector3.Distance(banner.transform.position, Camera.main.transform.position) > 750 || CameraController.instance.transform.position.y == CameraController.instance.maxY)
            {
                banner.gameObject.SetActive(false);
            }
            else
            {
                banner.gameObject.SetActive(true);
                float x = Camera.main.transform.rotation.x-banner.transform.rotation.x;
                banner.transform.Rotate(x,0,0);
            }
        }
    }
}
