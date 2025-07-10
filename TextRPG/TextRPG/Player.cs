using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player
    {
        private static Player _instance;

        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }

        public string? name;
        public int lv;
        public string? playClass;
        public int power;
        public int defense;
        public int MAXhp;
        public int hp;
        public int gold;

        public int additionalPower;
        public int additionalDefense;

        public List<string> playerClasses;

        // 가지고 있는 아이템
        public List<Item> playerItems;

        private Player()
        {
            name = null;
            lv = 1;
            playClass = null;
            power = 10;
            defense = 5;
            MAXhp = 100;
            hp = MAXhp;

            gold = 1500;
            additionalPower = 0;
            additionalDefense = 0;
            playerClasses = GameManager.Instance.dataManager.PlayerClassType();
            playerItems = new List<Item>();
        }

        public void ItemShopping(int price)
        {
            gold -= price;
        }

        public void ItemSale(int price)
        {
            gold += price;
        }

        public void ItemAdditional()
        {
            additionalPower = 0;
            additionalDefense = 0;

            power = 10;
            defense = 5;

            foreach (Item item in playerItems)
            {
                if(item.IsEquipped)
                {
                    if(item.abilityName == "공격력")
                    {
                        additionalPower += item.ability;
                        power += item.ability;
                    }
                    else if(item.abilityName == "방어력")
                    {
                        additionalDefense += item.ability;
                        defense += item.ability;
                    }
                }
            }
        }
    }
}
