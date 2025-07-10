namespace TextRPG
{
    internal class InventoryScene : Scene
    {
        enum InventorySceneState
        {
            Inventory,
            Installation,
            MainMenu
        }
        public override void Init()
        {
            currentState = (int)InventorySceneState.Inventory;
        }

        public override void Update()
        {
            switch (currentState)
            {
                case (int)InventorySceneState.Inventory:
                    ItemListScene();
                    break;
                case (int)InventorySceneState.Installation:
                    InstallationScene();
                    break;
                case (int)InventorySceneState.MainMenu:
                    GameManager.Instance.currentScene = (int)PlayScene.MainScene;
                    Clear();
                    break;
            }
            Loading();
        }

        public override void Clear()
        {
            currentState = (int)InventorySceneState.Inventory;
            choice = 0;
        }
        private void ItemListScene()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Player.Instance.playerItems.Count; i++)
            {
                Item item = Player.Instance.playerItems[i];
                if (item.IsEquipped)
                {
                    Console.Write("- [E]");
                }
                else
                    Console.Write("- ");

                Console.WriteLine($" {item.name}\t| {item.abilityName} " +
                                      $"+{item.ability}\t| {item.description}");
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리\n0. 나가기");
            Console.WriteLine();

            choice = BehaviorCheck(0, 1);

            switch (choice)
            {
                case 1:
                    currentState = (int)InventorySceneState.Installation;
                    break;
                case 0:
                    currentState = (int)InventorySceneState.MainMenu;
                    break;
            }
        }

        private void InstallationScene()
        {
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Player.Instance.playerItems.Count; i++)
            {
                Item item = Player.Instance.playerItems[i];
                if (item.IsEquipped)
                {
                    Console.Write("- [E]");
                }
                else
                    Console.Write("- ");

                Console.WriteLine($" {i + 1} {item.name}\t| {item.abilityName} " +
                                      $"+{item.ability}\t| {item.description}");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            choice = BehaviorCheck(0, Player.Instance.playerItems.Count);

            if( choice == 0 )
                currentState = (int)InventorySceneState.Inventory;
            else
            {
                Player.Instance.playerItems[choice - 1].IsEquipped = !Player.Instance.playerItems[choice - 1].IsEquipped;
            }
        }
    }
}
