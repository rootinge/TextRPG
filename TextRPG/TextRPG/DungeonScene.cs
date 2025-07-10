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
                    break;
                case (int)DungeonSceneState.Dungeon:
                    EenterDungeon();
                    break;
                case (int)DungeonSceneState.MainMenu:
                    Clear();
                    break;
            }
        }

        public override void Clear()
        {
            currentDungeon = null;
            currentState = (int)DungeonSceneState.DungeonMenu;
        }

        public void DungeonMenu()
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            for(int i = 0; i < dungeons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dungeons[i].name}\t| 방어력 {dungeons[i].defensive} 이상 권장");
            }
            Console.WriteLine("0. 나가기\n");
            choice = BehaviorCheck(0,dungeons.Count);

            if (choice == 0)
            {
                currentState = (int)DungeonSceneState.DungeonMenu;
            }
            else
            {
                currentState = (int)DungeonSceneState.Dungeon;
                currentDungeon = dungeons[choice - 1];
            }
        }


        public void EenterDungeon()
        {
            
        }
    }
}
