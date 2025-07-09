using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player : GameObject
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
        public string? chad;
        public int power;
        public int defense;
        public int hp;
        public int gold;

        public List<string> playerClass;

        private Player()
        {
            name = null;
            lv = 1;
            chad = null;
            power = 10;
            defense = 5;
            hp = 100;
            gold = 1500;
            playerClass = GameManager.Instance.dataManager.PlayerClassType();
        }

        public override void Update()
        {

        }

    }
}
