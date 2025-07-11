using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class DataManager
    {
        // 저장 위치
        public static string savePath = "C:\\GitHub\\TextRPG\\TextRPG\\save.json";

        // 플레이어 직업
        public List<string> PlayerClassType()
        {

            List<string> lset = new List<string>();
            lset.Add("전사");
            lset.Add("도적");
            lset.Add("사제");
            lset.Add("모험가");
            return lset;
        }

        // 게임 시작 화면 씬
        public List<string> MainSceneType()
        {
            List<string> lset = new List<string>();
            lset.Add("상태 보기");
            lset.Add("인벤토리");
            lset.Add("상점");
            lset.Add("던전입장");
            lset.Add("휴식하기");
            return lset;
        }

        // 상점 물품
        public List<Item> ItemType()
        {
            List<Item> lset = new List<Item>();
            lset.Add(new Item("수련자 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", 1000));
            lset.Add(new Item("무쇠갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500));
            lset.Add(new Item("스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
            lset.Add(new Item("낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600));
            lset.Add(new Item("청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500));
            lset.Add(new Item("스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2000));
            return lset;
        }

        public List<Dungeon> DungeonType()
        {
            List<Dungeon> lset = new List<Dungeon>();
            lset.Add(new Dungeon("쉬운", 5, 1000));
            lset.Add(new Dungeon("일반", 11, 1700));
            lset.Add(new Dungeon("어려운", 17, 2500));

            return lset;
        }


        public static void SavePlayer(string path)
        {
            var json = JsonSerializer.Serialize(Player.Instance);
            File.WriteAllText(path, json);
            Environment.Exit(0);
        }

        public static void LoadPlayer(string path)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("저장된 플레이어가 없습니다.");

                return;
            }

            var json = File.ReadAllText(path);

            var loadedPlayer = JsonSerializer.Deserialize<Player>(json);

            if (loadedPlayer != null)
            {
                Player.Instance.name = loadedPlayer.name;
                Player.Instance.lv = loadedPlayer.lv;
                Player.Instance.playClass = loadedPlayer.playClass;
                Player.Instance.basePower = loadedPlayer.basePower;
                Player.Instance.baseDefense = loadedPlayer.baseDefense;
                Player.Instance.power = loadedPlayer.power;
                Player.Instance.defense = loadedPlayer.defense;
                Player.Instance.maxHp = loadedPlayer.maxHp;
                Player.Instance.hp = loadedPlayer.hp;
                Player.Instance.gold = loadedPlayer.gold;
                Player.Instance.currentExperience = loadedPlayer.currentExperience;
                Player.Instance.maxExperience = loadedPlayer.maxExperience;
                Player.Instance.additionalPower = loadedPlayer.additionalPower;
                Player.Instance.additionalDefense = loadedPlayer.additionalDefense;
                Player.Instance.playerClasses = loadedPlayer.playerClasses;
                Player.Instance.playerItems = loadedPlayer.playerItems;

                GameManager.Instance.currentScene = (int)PlayScene.MainScene;

                for(int i = 0; i < Player.Instance.playerItems.Count; i++)
                {
                    for(int j = 0; j < GameManager.Instance.itemList.Count; j++)
                    {
                        if (Player.Instance.playerItems[i].name == GameManager.Instance.itemList[j].name)
                        {
                            GameManager.Instance.itemList[j] = Player.Instance.playerItems[i];
                        }
                    }
                }
            }
        }
    }
}
