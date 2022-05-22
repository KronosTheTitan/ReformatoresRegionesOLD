using System.Collections.Generic;
using UIHandeling;
using UnityEngine;

//[ExecuteInEditMode]
namespace GameWorld
{
    public class Province : MonoBehaviour
    {
        public Country owningCountry;
        public Army occupationArmy;
        public Transform armyPos;
        public Navy port;

        public int id;

        public int develpomentLevel = 1;

        [SerializeField]
        public List<Province> landNeighbours = new List<Province>();
        [SerializeField]
        public List<Province> seaNeighbours = new List<Province>();

        public ProvinceUI provinceUI;

        [SerializeField]
        ProvinceDiploMenuUI provinceDiplo;

        [SerializeField]
        ProvinceMenuUI provinceMenu;
        private void Update()
        {
            gameObject.name = "Province" + id;
            provinceUI.UpdateProvinceBanner(GameManager.instance.activeCountry);
        }
        public void OnNextTurn()
        {
            UpdateProvinceYield();
        }
        public virtual void ChangeOwner(Country newOwner)
        {
            owningCountry.ownedProvinces.Remove(this);
            if (owningCountry.Capital == this)
            {
                owningCountry.PickCapital();
            }
            owningCountry = newOwner;
            provinceUI.UpdateProvinceBanner(GameManager.instance.activeCountry);
        }

        void UpdateProvinceYield()
        {
            int goldYield = develpomentLevel * 5;
            int manPower = develpomentLevel;
            owningCountry.manpowerCap += manPower;
            owningCountry.treasury += goldYield;
        }
        public void Click()
        {
            if(GameManager.instance.selectedUnit != null)
            {
                GameManager.instance.selectedUnit.Move(this);
            }
            else
            {
                if (GameManager.instance.activeCountry == owningCountry)
                {
                    provinceMenu.OpenMenu();
                }
                else
                {
                    provinceDiplo.OpenMenu();
                }
            }
        }
        public void ResolveBattle(Army attacker,Army defender)
        {
            int aDam;
            int dDam;
            int aDamT = 0;
            int dDamT = 0;
            aDam = attacker.InflictDamage(attacker.cavalry);
            aDamT += aDam;
            dDam = defender.InflictDamage(defender.cavalry);
            dDamT += dDam;
            if (attacker.TakeDamage(dDam, true)) return;
            if (defender.TakeDamage(aDam, true)) return;
            aDam = attacker.InflictDamage(attacker.infantry + (defender.artillery)*2);
            aDamT += aDam;
            dDam = defender.InflictDamage(defender.infantry + (defender.artillery)*2);
            dDamT += dDam;
            if (attacker.TakeDamage(dDam, false)) return;
            if (defender.TakeDamage(aDam, false)) return;

            if(aDamT > dDamT)
            {
                defender.Retreat(this);
                attacker.movementPoints++;
                attacker.Move(this);
            }
            else
            {
                attacker.Retreat(this);
            }
            GameManager.ForceUIUpdate();
        }

        public void CreateNewArmy()
        {
            foreach (Army army in owningCountry.armies)
            {
                if (!army.CheckIfDead()) continue;
                army.RaiseArmy(this);
                return;
            }
        }

        public void IncreaseDevelopment()
        {
            if (develpomentLevel > 2) return;
            develpomentLevel++;
        }
    }
}
