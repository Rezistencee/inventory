using System;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Sword : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Damage { get; set; }

        public Sword()
        {
            Name = String.Empty;
            Description = String.Empty;
            Weight = 0.0f;
            Damage = 0;
        }

        public Sword(string name, string description, float weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
        }
        
        public Sword(string name, string description, float weight, int damage)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Damage = damage;
        }
        
        public void Use()
        {
            Console.WriteLine("You use your {0} sword, which has {1} damage", Name, Damage);
        }
    }
}