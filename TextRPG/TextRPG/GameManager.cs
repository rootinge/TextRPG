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
        }

        public PlayScene currentScene = PlayScene.StartScene;
    }
}
