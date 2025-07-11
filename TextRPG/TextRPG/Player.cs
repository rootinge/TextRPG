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

        public string? name { get; set; }
        public int lv { get; set; }
        public string? playClass { get; set; }

        // 플레이어 능력치
        public int basePower { get; set; }
        public int baseDefense { get; set; }
        // 플레이어 능력치 총합
        public int power { get; set; }
        public int defense { get; set; }

        public int maxHp { get; set; }
        public int hp { get; set; }
        public int gold { get; set; }

        // 경험치
        public int currentExperience { get; set; }
        public int maxExperience { get; set; }

        public int additionalPower { get; set; }
        public int additionalDefense { get; set; }

        public List<string> playerClasses;

        // 가지고 있는 아이템
        public List<Item> playerItems;

        public Player()
        {
            name = null;
            lv = 1;
            playClass = null;
            basePower = 10;
            baseDefense = 5;
            power = basePower;
            defense = baseDefense;
            maxHp = 100;
            hp = maxHp;

            currentExperience = 0;
            maxExperience = 1;

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

            power = basePower;
            defense = baseDefense;

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

        public void DungeonClear(int damage, int gold = 0)
        {
            if (damage > 0)
            {
                hp -= damage;
                if (hp < 0)
                {
                    hp = 0;
                }
            }

            this.gold += gold;
        }

        public void PlayerDie()
        {
            Console.WriteLine("캐릭터가 죽었습니다.");
            Console.WriteLine("게임을 종료합니다.");
            string savePath = DataManager.savePath;
            if (File.Exists(savePath))
                File.Delete(savePath);
            Environment.Exit(0);
        }

        public void GainExperience()
        {
            currentExperience++;
            if (currentExperience >= maxExperience)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            maxExperience++;
            currentExperience = 0;
            lv++;
            basePower += 2;
            baseDefense += 1;
            power = basePower + additionalPower;
            defense = baseDefense + additionalDefense;
            Console.WriteLine($"\n레벨업! 현재 레벨 : {lv}");
            Console.WriteLine($"공격력 : 2↑   방어력 : 1↑");
        }
    }
}
