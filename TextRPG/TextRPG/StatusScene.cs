using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class StatusScene : Scene
    {
        public override void Update() 
        {

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {Player.Instance.lv} ({Player.Instance.currentExperience}/{Player.Instance.maxExperience})");
            Console.WriteLine($"{Player.Instance.name} ({Player.Instance.playClass})");


            Console.Write($"공격력 : {Player.Instance.power} ");
            if (Player.Instance.additionalPower != 0)
                Console.WriteLine($"(+{Player.Instance.additionalPower})");
            else
                Console.WriteLine();

                Console.Write($"방어력 : {Player.Instance.defense} ");
            if (Player.Instance.additionalDefense != 0)
                Console.WriteLine($"(+{Player.Instance.additionalDefense})");
            else
                Console.WriteLine();

            Console.WriteLine($"체력 : {Player.Instance.hp}");
            Console.WriteLine($"Gold : {Player.Instance.gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            choice = BehaviorCheck(0,0);
            GameManager.Instance.currentScene = (int)PlayScene.MainScene;
            Loading();
        }
    }
}
