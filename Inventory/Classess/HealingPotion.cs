using System;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class HealingPotion : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int RegenerationValue { get; set; }

        public HealingPotion()
        {
            Name = String.Empty;
            Description = String.Empty;
            Weight = 0.0f;
            RegenerationValue = 0;
        }

        public HealingPotion(string name, string description, float weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
            RegenerationValue = 0;
        }
        
        public HealingPotion(string name, string description, float weight, int regenerationValue)
        {
            Name = name;
            Description = description;
            Weight = weight;
            RegenerationValue = regenerationValue;
        }
        
        public void Use()
        {
            Console.WriteLine("You use your {0} potion, which has {1} healing value", Name, RegenerationValue);
        }
    }
}