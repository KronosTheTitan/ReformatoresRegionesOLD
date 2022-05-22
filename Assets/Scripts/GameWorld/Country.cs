using System.Collections.Generic;
using AI_Country;
using EventSystem;
using UnityEngine;

namespace GameWorld
{
    public class Country : MonoBehaviour
    {
        public string countryName;

        public int manpowerCap;
        public int manpowerCurrent;
        public int manpowerUsed;
        public int manpowerGraveyard0;
        int _manpowerGraveyard1;
        int _manpowerGraveyard2;

        public int treasury;

        public Culture culture;

        public Sprite flag;

        public List<Province> ownedProvinces;
        [SerializeField] private Province _capital;

        public Province Capital
        {
            get
            {
                return _capital;
            }
        }

        [SerializeField] public Army[] armies;
        [SerializeField] private Navy navy;

        public bool inEmpire;

        public List<War> activeWars;
        public List<Country> atWarWith;
        public List<Country> activeAlliances;

        public Ruler ruler;
        public int rulerSkillStored;
        
        public Government government;

        bool _isVassal;
        Country _overlord;

        List<Country> _vassals;

        public bool aiControlled;

        [SerializeField]
        CountryAI countryAI;

        public List<EventCard> eventQueue;

        private void Start()
        {
            gameObject.name = countryName;
            government.NewRuler(culture);
        }

        public void OnNextTurn()
        {
            manpowerCap = 0;
            
            foreach (Army army in armies)
            {
                army.Siege();
                army.movementPoints = 2;
            }

            foreach (Province province in ownedProvinces)
            {
                province.OnNextTurn();
            }
            
            government.NewRuler(culture);

            rulerSkillStored += ruler.RulerSkill;
            
            UpdateManpower();
        }
        public void DeclareWarUpon(Country attacker)
        {
            if(attacker.activeAlliances.Contains(this)) return;
            GameObject warObject = new GameObject();
            War war = warObject.AddComponent(typeof (War)).GetComponent<War>();
            war.StartWar(attacker, this);
            GameManager.ForceUIUpdate();
        }
        void UpdateManpower()
        {
            _manpowerGraveyard2 = _manpowerGraveyard1;
            _manpowerGraveyard1 = manpowerGraveyard0;
            manpowerCurrent = manpowerCap - manpowerUsed - _manpowerGraveyard1 - _manpowerGraveyard2;
        }
        public void RunAI(GameManager gameManager)
        {
            if (ownedProvinces.Count <= 0)
            {
                gameManager.NextTurn();
            }
            if (!aiControlled) return;
            countryAI.RunAI();
        }
        public void PickCapital()
        {
            List < Province > l3 = new List<Province>();
            List < Province > l2 = new List<Province>();
            List < Province > l1 = new List<Province>();
            foreach(Province province in ownedProvinces)
            {
                if (province.develpomentLevel == 3)
                    l3.Add(province);
                if (province.develpomentLevel == 2)
                    l2.Add(province);
                if (province.develpomentLevel == 1)
                    l1.Add(province);
            }
            if (l3.Count >= 1)
                _capital = l3[Random.Range(0, l3.Count)];
            else if (l2.Count >= 1)
                _capital = l2[Random.Range(0, l2.Count)];
            else if (l1.Count >= 1)
                _capital = l1[Random.Range(0, l1.Count)];
        }
        public int GetArmyWeight()
        {
            int output = 0;
            foreach (Army army in armies)
                output += army.infantry + army.cavalry + (army.artillery*2);
            return output;
        }
        /// <summary>
        /// This function updates the list of countries this country is currently at war with.
        /// </summary>
        public void UpdateAtWarWithList()
        {
            atWarWith.Clear();
            foreach(War war in activeWars)
            {
                if (war.defenders.Contains(this))
                    atWarWith.AddRange(war.attackers);
                else
                    atWarWith.AddRange(war.defenders);
            }
        }
    }
}
