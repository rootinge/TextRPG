using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class RestScene : Scene
    {
        enum RestSceneState
        {
            RestMenu,
            Rest,
            MainMenu
        }

        public override void Init()
        {
            currentState = (int)RestSceneState.RestMenu;
            choice = 0;
        }

        public override void Update()
        {
            
            switch (currentState)
            {
                case (int)RestSceneState.RestMenu:
                    RestMenu();
                    Loading();
                    break;
                case (int)RestSceneState.Rest:
                    Rest();
                    break;
                case (int)RestSceneState.MainMenu:
                    GameManager.Instance.currentScene = (int)PlayScene.MainScene;
                    Loading();
                    Clear();
                    break;
            }
        }

        public override void Clear()
        {
            currentState = (int)RestSceneState.RestMenu;
            choice = 0;
        }

        private void RestMenu()
        {
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {Player.Instance.gold} G)");
            Console.WriteLine("\n1. 휴식하기\n0. 나가기");
            choice = BehaviorCheck(0, 1);

            switch(choice)
            {
                case 1:
                    if (Player.Instance.gold < 500)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        currentState = (int)RestSceneState.RestMenu;
                    }
                    else if (Player.Instance.hp == Player.Instance.maxHp)
                    {
                        Console.WriteLine("체력이 이미 최대입니다.");
                        currentState = (int)RestSceneState.RestMenu;
                    }
                    else
                        currentState = (int)RestSceneState.Rest;
                    break;
                case 0:
                    currentState = (int)RestSceneState.MainMenu;
                    break;
            }
        }

        private void Rest()
        {
            Console.Write("휴식중 \n\n");
            Console.Write($"체력 {Player.Instance.hp} -> ");
            while(Player.Instance.hp < Player.Instance.maxHp)
            {
                Thread.Sleep(50);
                Player.Instance.hp++;
                Console.SetCursorPosition(11, 2);
                Console.Write($"{Player.Instance.hp}");
            }
            
            Player.Instance.gold -= 500;
            Console.WriteLine($"\n\n체력이 회복되었습니다. (보유 골드 : {Player.Instance.gold} G) ");

            Console.WriteLine("\n0. 나가기");
            choice = BehaviorCheck(0, 0);
            currentState = (int)RestSceneState.MainMenu;
        }

        
    }
}
