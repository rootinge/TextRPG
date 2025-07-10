using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class StartScene : Scene
    {
        enum StartSceneState
        {
            InputName,
            NameCheck,
            SelectClass,
            MainMenu
        }

        public override void Init()
        {
            currentState = (int)StartSceneState.InputName;
        }

        public override void Update()
        {
            switch (currentState)
            {
                case (int)StartSceneState.InputName:
                    InputName();
                    break;
                case (int)StartSceneState.NameCheck:
                    NameConfirmation();
                    break;
                case (int)StartSceneState.SelectClass:
                    SelectClass();
                    break;
                case (int)StartSceneState.MainMenu:
                    GameManager.Instance.currentScene = (int)PlayScene.MainScene;
                    break;
            }
            Loading();
        }


        // 시작 시 이름
        void InputName()
        {

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");

            Player.Instance.name = Console.ReadLine();
            currentState = (int)StartSceneState.NameCheck;

        }

        // 이름 선택 확인
        void NameConfirmation()
        {
            Console.WriteLine($"입력하신 이름은 {Player.Instance.name} 입니다.");
            Console.WriteLine();
            Console.WriteLine("1. 저장 \n2. 취소");
            choice = BehaviorCheck(1, 2);

            if (choice == 1)
            {
                Console.WriteLine($"이름 '{Player.Instance.name}'이(가) 저장되었습니다.");
                currentState = (int)StartSceneState.SelectClass;
            }
            else if (choice == 2)
            {
                Console.WriteLine("이름 설정을 취소합니다. 다시 입력해주세요.");
                Player.Instance.name = null;
                currentState = (int)StartSceneState.InputName;
            }

        }

        void SelectClass()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요");
            Console.WriteLine();

            for (int i = 0; i < Player.Instance.playerClasses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Player.Instance.playerClasses[i]}");
            }
            Console.WriteLine();

            choice = BehaviorCheck(1, Player.Instance.playerClasses.Count);

            Console.WriteLine($"{Player.Instance.playerClasses[choice - 1]}를(을) 선택하셨습니다.");
            Player.Instance.playClass = Player.Instance.playerClasses[choice - 1];
            Console.WriteLine("스파르타 던전으로 들어갑니다.");

            currentState = (int)StartSceneState.MainMenu;
        }
    }
}
