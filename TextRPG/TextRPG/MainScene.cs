using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class MainScene : Scene
    {
        List<String> activity;

        public override void Init()
        {
            activity = GameManager.Instance.dataManager.MainSceneType();
        }

        public override void Update()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            for (int i = 0; i < activity.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activity[i]}");
            }
            Console.WriteLine("0. 저장 후 나가기");
            Console.WriteLine();
            choice = BehaviorCheck(0, activity.Count);

            for (int i = 2; i < activity.Count + 2; i++)
            {
                if (choice + 1 == i)
                    GameManager.Instance.currentScene = choice + 1;
            }

            if (choice == 0)
            {
                Console.WriteLine("게임을 저장하고 종료합니다.");
                DataManager.SavePlayer(DataManager.savePath);

            }

            Loading();
        }

    }
}
