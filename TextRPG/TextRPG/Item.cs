using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        public string? name; 
        public string? abilityName; // 능력
        public int ability;         // 능력치
        public string? description; // 설명
        public int price;           // 가격
        public bool hasItem;        // 템을 가지고 있는지
        public bool IsEquipped;     // 장착 중인지

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
