using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        public string? name { get; set; }
        public string? abilityName { get; set; } // 능력
        public int ability { get; set; }         // 능력치
        public string? description { get; set; } // 설명
        public int price { get; set; }           // 가격
        public bool hasItem { get; set; }        // 템을 가지고 있는지
        public bool IsEquipped { get; set; }    // 장착 중인지

        // 아이템 이름, 능력치 이름, 능력치, 아이템 설명, 가격
        public Item(string? name, string? abilityName, int ability, string? description, int price)
        {
            this.name = name;
            this.abilityName = abilityName;
            this.ability = ability;
            this.description = description;
            this.price = price;
            hasItem = false;
            IsEquipped = false;
        }

    }
}
