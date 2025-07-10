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
        public string? abilityName;
        public int ability;
        public string? description;
        public int price;
        public bool hasItem;
        public bool IsEquipped;
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
