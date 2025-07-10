using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    

    internal class GameManager
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        public DataManager dataManager;
        GameManager()
        {
            dataManager = new DataManager();
            itemList = new List<Item>();

            itemList = dataManager.ItemType();
        }

        // 상점 아이템
        public List<Item> itemList;

        // 메인씬 변경 변수
        public int currentScene = (int)PlayScene.StartScene;
    }
}
