using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class DungeonScene : Scene
    {
        enum DungeonSceneState
        {
            DungeonMenu,
            Hunting,
            Dungeon,
            MainMenu
        }

        private List<Dungeon> dungeons;
        private Dungeon? currentDungeon = null;

        public override void Init()
        {
            dungeons = GameManager.Instance.dataManager.DungeonType();
            currentDungeon = null;
            currentState = (int)DungeonSceneState.DungeonMenu;
        }

        public override void Update()
        {
            switch (currentState)
            {
                case (int)DungeonSceneState.DungeonMenu:
                    DungeonMenu();
                    Loading();
                    break;
                case (int)DungeonSceneState.Hunting:
                    Hunting();
                    currentState = (int)DungeonSceneState.Dungeon;
                    break;
                case (int)DungeonSceneState.Dungeon:
                    clearDungeon();
                    Loading();
                    break;
                case (int)DungeonSceneState.MainMenu:
                    Clear();
                    GameManager.Instance.currentScene = (int)PlayScene.MainScene;
                    Loading();
                    break;
            }
        }

        public override void Clear()
        {
            currentDungeon = null;
            currentState = (int)DungeonSceneState.DungeonMenu;
        }

        private void DungeonMenu()
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            for(int i = 0; i < dungeons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dungeons[i].name} 던전\t| 방어력 {dungeons[i].defensive} 이상 권장");
            }
            Console.WriteLine("0. 나가기\n");
            choice = BehaviorCheck(0,dungeons.Count);

            if (choice == 0)
            {
                currentState = (int)DungeonSceneState.MainMenu;
            }
            else
            {
                currentState = (int)DungeonSceneState.Hunting;
                currentDungeon = dungeons[choice - 1];
            }
        }

        private void Hunting()
        {
            Console.Write("사냥중");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
        }

        private void clearDungeon()
        {
            Random random = new Random();
            int currenthp = Player.Instance.hp;
            int currentgold = Player.Instance.gold;
            if (Player.Instance.defense < currentDungeon.defensive && random.Next(0, 10) < 4)
            {
                Console.WriteLine("던전 실패");
                Console.WriteLine("방어력이 부족하여 던전을 클리어하지 못했습니다.\n");
                int damage = currentDungeon.DungeonDamage() / 2;
                Player.Instance.DungeonClear(damage);
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {currenthp} -> {Player.Instance.hp}");
            }
            else
            {
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"{currentDungeon.name} 던전을 클리어 하였습니다.\n");
                int damage = currentDungeon.DungeonDamage();
                int gold = currentDungeon.ClaerGold();
                Player.Instance.DungeonClear(damage, gold);
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {currenthp} -> {Player.Instance.hp}");
                Console.WriteLine($"Gold {currentgold} G -> {Player.Instance.gold} G");

                Player.Instance.GainExperience();
            }

            if(Player.Instance.hp <= 0)
            {
                Player.Instance.PlayerDie();
            }

            Console.WriteLine("\n0. 나가기");
            choice = BehaviorCheck(0, 0);

            if (choice == 0)
            {
                currentState = (int)DungeonSceneState.DungeonMenu;
            }
        }

    }
}
