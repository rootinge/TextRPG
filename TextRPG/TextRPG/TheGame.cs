using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum PlayScene
    {
        StartScene,
        MainScene,
        StatusScene,
        InventoryScene,
        StoreScene,
        DungeonScene,
        RestScene
    }

    internal class TheGame
    {
        public bool running = true;

        List<IScene> scene = new List<IScene>();
        //List<Scene> scene = new List<Scene>();
        public void Init()
        {
            scene.Clear();
            scene.Add(new StartScene());
            scene.Add(new MainScene());
            scene.Add(new StatusScene());
            scene.Add(new InventoryScene());
            scene.Add(new StoreScene());
            scene.Add(new DungeonScene());
            scene.Add(new RestScene());

            foreach(IScene list in scene)
            {
                list.Init();
            }
        }

        public void Update()
        {
            Console.Clear();
            switch (GameManager.Instance.currentScene)
            {
                case (int)PlayScene.StartScene:
                    scene[(int)PlayScene.StartScene].Update();
                    break;
                case (int)PlayScene.MainScene:
                    scene[(int)PlayScene.MainScene].Update();
                    break;
                case (int)PlayScene.StatusScene:
                    scene[(int)PlayScene.StatusScene].Update();
                    break;
                case (int)PlayScene.InventoryScene:
                    scene[(int)PlayScene.InventoryScene].Update();
                    break;
                case (int)PlayScene.StoreScene:
                    scene[(int)PlayScene.StoreScene].Update();
                    break;
                case (int)PlayScene.DungeonScene:
                    scene[(int)PlayScene.DungeonScene].Update();
                    break;
                case (int)PlayScene.RestScene:
                    scene[(int)PlayScene.RestScene].Update();
                    break;
            }
        }
    }

}
