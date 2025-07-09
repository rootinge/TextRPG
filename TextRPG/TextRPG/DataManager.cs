using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class DataManager
    {
        // 플레이어 직업
        public List<string> PlayerClassType()
        {
            List<string> lset = new List<string>();
            lset.Add("전사");
            lset.Add("도적");
            lset.Add("사제");
            lset.Add("모험가");
            lset.Add("모험가");

            return lset;
        }

        // 게임 시작 화면 씬
        public List<string> SceneType()
        {
            List<string> lset = new List<string>();
            lset.Add("상태 보기");
            lset.Add("인벤토리");
            lset.Add("상점");
            lset.Add("던전입장");
            lset.Add("휴식하기");
            return lset;
        }
        
    }
}
