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

        private StartSceneState currentState = StartSceneState.InputName;

        public override void Update()
        {
            switch (currentState)
            {
                case StartSceneState.InputName:
                    InputName();
                    break;
                case StartSceneState.NameCheck:
                    NameConfirmation();
                    break;
                case StartSceneState.SelectClass:
                    SelectClass();
                    break;
                case StartSceneState.MainMenu:
                    gameManager.currentScene = PlayScene.MainScene;
                    break;
            }
        }


        // 시작 시 이름
        void InputName()
        {

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");

            player.name = Console.ReadLine();
            currentState = StartSceneState.NameCheck;
            Loading();
        }

        // 이름 선택 확인
        void NameConfirmation()
        {
            Console.WriteLine($"입력하신 이름은 {player.name} 입니다.");
            Console.WriteLine();
            Console.WriteLine("1. 저장 \n2. 취소");
            choice = BehaviorCheck(1, 2);

            if (choice == 1)
            {
                Console.WriteLine($"이름 '{player.name}'이(가) 저장되었습니다.");
                currentState = StartSceneState.SelectClass;
            }
            else if (choice == 2)
            {
                Console.WriteLine("이름 설정을 취소합니다. 다시 입력해주세요.");
                player.name = null;
                currentState = StartSceneState.InputName;
            }
            Loading();
        }

        void SelectClass()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요");
            Console.WriteLine();

            for (int i = 0; i < player.playerClass.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.playerClass[i]}");
            }
            Console.WriteLine();

            choice = BehaviorCheck(1, player.playerClass.Count);

            Console.WriteLine($"{player.playerClass[choice - 1]}를(을) 선택하셨습니다.");
            Console.WriteLine("스파르타 던전으로 들어갑니다.");
            Loading();
            currentState = StartSceneState.MainMenu;
        }
    }
}
