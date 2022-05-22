using GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace UIHandeling
{
    public class ProvinceUI : MonoBehaviour
    {
        [SerializeField]
        Province province;

        [SerializeField]
        Canvas banner;

        [SerializeField]
        Image bannerImage;

        [SerializeField]
        Image bannerFlag;

        [SerializeField]
        Text nameText;

        [SerializeField]
        Text provinceLevel;

        [SerializeField]
        Sprite bannerAtWar;
        [SerializeField]
        Sprite bannerAtPeace;
        [SerializeField]
        Sprite bannerAllied;
        [SerializeField]
        Sprite bannerOwned;
        [SerializeField]
        Image cappitalImage;

        public void UpdateProvinceBanner(Country activeCountry)
        {
            nameText.text = province.owningCountry.culture.provinceNames[province.id];
            bannerFlag.sprite = province.owningCountry.flag;
            if (province.owningCountry == activeCountry)
            {
                bannerImage.sprite = bannerOwned;
            }
            else
            {
                bannerImage.sprite = bannerAtPeace;
            }
            if(activeCountry.activeAlliances.Count != 0)
                if (activeCountry.activeAlliances.Contains(province.owningCountry))
                {
                    bannerImage.sprite = bannerAllied;
                }
            if (activeCountry.atWarWith.Count != 0)
                if (activeCountry.atWarWith.Contains(province.owningCountry))
                {
                    bannerImage.sprite = bannerAtWar;
                }
            if (province.owningCountry.Capital == province)
                cappitalImage.gameObject.SetActive(true);
            else
                cappitalImage.gameObject.SetActive(false);
        }
        public void Update()
        {
            if (Vector3.Distance(banner.transform.position, Camera.main.transform.position) > 750 || CameraController.instance.transform.position.y == CameraController.instance.maxY)
            {
                banner.gameObject.SetActive(false);
            }
            else
            {
                banner.gameObject.SetActive(true); banner.gameObject.SetActive(true);
                float x = Camera.main.transform.rotation.x-banner.transform.rotation.x;
                banner.transform.Rotate(x,0,0);
            }
        }
    }
}
