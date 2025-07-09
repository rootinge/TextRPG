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
        RelaxScene
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
                case PlayScene.StartScene:
                    scene[(int)PlayScene.StartScene].Update();
                    break;
                case PlayScene.MainScene:
                    scene[(int)PlayScene.MainScene].Update();
                    break;
            }
        }
    }

}
