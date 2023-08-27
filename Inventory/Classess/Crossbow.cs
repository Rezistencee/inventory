using System;
using Inventory.Converters;
using Inventory.Enums;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Crossbow : IItem, IRangedWeapon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public Rarity Rarity { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }

        public Crossbow()
        {
            Name = String.Empty;
            Description = String.Empty;
            Weight = 0.0f;
            Rarity = Rarity.Common;
            Range = 0;
            Damage = 0;
        }
        
        public Crossbow(string name, string description, float weight, int range)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = Rarity.Common;
            Range = range;
            Damage = 0;
        }
        
        public Crossbow(string name, string description, float weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = Rarity.Common;
            Damage = 0;
            Range = 0;
        }
        
        public Crossbow(string name, string description, float weight, int range, Rarity rarity)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = rarity;
            Damage = 0;
            Range = range;
        }
        
        public Crossbow(string name, string description, float weight, int range, int rarityValue)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = RarityConverter.Convert(rarityValue);
            Damage = 0;
            Range = range;
        }
        
        public void Use()
        {
            Console.WriteLine("You use your {0} crossbow, which has {1} damage and {2} range", Name, Damage, Range);
        }
        
        public void Fire(int distance)
        {
            if(distance <= Range)
                Console.WriteLine("Fire from {0} and give a {1} damage to enemy!", Name, Damage);
            else
                Console.WriteLine("You can't fire from this weapon to this distance!");
        }
    }
}