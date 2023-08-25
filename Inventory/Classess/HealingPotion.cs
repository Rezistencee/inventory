using System;
using System.Collections;
using Inventory.Enums;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class HealingPotion : IItem, IConsumables
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Rarity Rarity { get; set; }
        public int RegenerationValue { get; set; }
        public int StackableLimit { get; set; }
        public int Quantity { get; set; }

        public HealingPotion()
        {
            Name = String.Empty;
            Description = String.Empty;
            Weight = 0.0f;
            Rarity = Rarity.Common;
            RegenerationValue = 0;
            StackableLimit = 3;
            Quantity = 0;
        }

        public HealingPotion(string name, string description, float weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = Rarity.Common;
            RegenerationValue = 0;
            StackableLimit = 3;
            Quantity = 1;
        }
        
        public HealingPotion(string name, string description, float weight, int regenerationValue)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = Rarity.Common;
            RegenerationValue = regenerationValue;
            StackableLimit = 3;
            Quantity = 1;
        }
        
        public void Use()
        {
            if (Quantity > 0)
            {
                Console.WriteLine("You use your {0} potion, which has {1} healing value", Name, RegenerationValue);
            }
            else
            {
                Console.WriteLine("You can't use that.");
            }
        }
    }
}