namespace TextRPG
{


    internal class StoreScene : Scene
    {

        enum StoreSceneState
        {
            Store,
            ItemPurchase,
            ItemSale,
            MainMenu
        }

        public override void Init() { }

        public override void Update()
        {
            switch (currentState)
            {
                case (int)StoreSceneState.Store:
                    Store();
                    break;
                case (int)StoreSceneState.ItemPurchase:
                    ItemPurchase();
                    break;
                case (int)StoreSceneState.ItemSale:
                    ItemSale();
                    break;
                case (int)StoreSceneState.MainMenu:
                    GameManager.Instance.currentScene = (int)PlayScene.MainScene;
                    Clear();
                    break;
            }
            Loading();

        }

        public override void Clear()
        {
            currentState = (int)StoreSceneState.Store;
            choice = 0;
        }


        private void Store()
        {
            Console.WriteLine("상점");
            ItemPrint();
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");
            choice = BehaviorCheck(0, 2);

            switch (choice)
            {
                case 0:
                    currentState = (int)StoreSceneState.MainMenu;
                    break;
                case 1:
                    currentState = (int)StoreSceneState.ItemPurchase;
                    break;
                case 2:
                    currentState = (int)StoreSceneState.ItemSale;
                    break;
            }


        }

        private void ItemPurchase()
        {
            Console.WriteLine("상점 - 아이템 구매");
            ItemPrint(1);
            Console.WriteLine("0. 나가기\n");

            choice = BehaviorCheck(0, GameManager.Instance.itemList.Count);

            if (choice == 0)
            {
                currentState = (int)StoreSceneState.Store;
            }
            else
            {
                Item item = GameManager.Instance.itemList[choice - 1];
                if (item.hasItem)
                {
                    Console.WriteLine("이미 구매한 아이템 입니다.");
                }
                else if (Player.Instance.gold < item.price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    Player.Instance.ItemShopping(item.price);
                    item.hasItem = true;
                    Player.Instance.playerItems.Add(item);
                    Console.WriteLine("구매를 완료했습니다.");
                }
                Console.WriteLine();
            }
        }

        private void ItemSale()
        {
            Console.WriteLine("상점 - 아이템 판매");

            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Player.Instance.gold} G");

            for (int i = 0; i < Player.Instance.playerItems.Count; i++)
            {
                Item item = Player.Instance.playerItems[i];
                Console.Write("- ");
                Console.Write($"{i + 1}. ");

                Console.Write($"{item.name,-13}\t| {item.abilityName} " +
                              $"+{item.ability,-5}\t| {item.description,-10}\t| ");
                Console.WriteLine($"{item.price * 85 / 100}G");
            }
            Console.WriteLine("\n0. 나가기\n");
            choice = BehaviorCheck(0, Player.Instance.playerItems.Count);

            if (choice == 0)
            {
                currentState = (int)StoreSceneState.Store;
            }
            else
            {
                Item item = Player.Instance.playerItems[choice - 1];
                item.hasItem = false;
                if (item.IsEquipped)
                {
                    item.IsEquipped = false;
                    Player.Instance.ItemAdditional();
                }
                Player.Instance.ItemSale(item.price * 85 / 100);
                Player.Instance.playerItems.Remove(item);
            }
        }

        private void ItemPrint(int point = 0)
        {

            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{Player.Instance.gold} G");
            for (int i = 0; i < GameManager.Instance.itemList.Count; i++)
            {
                Item item = GameManager.Instance.itemList[i];

                Console.Write("- ");

                if (point == 1)
                    Console.Write($"{i + 1}. ");

                Console.Write($"{item.name,-13}\t| {item.abilityName} " +
                              $"+{item.ability,-5}\t| {item.description,-10}\t| ");


                if (item.hasItem)
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine($"{item.price}G");
                }


            }
        }

    }
}
