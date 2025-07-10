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
        public int hp;
        public int gold;

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
            hp = 100;
            gold = 1500;
            playerClasses = GameManager.Instance.dataManager.PlayerClassType();
            playerItems = new List<Item>();
        }
    }
}
