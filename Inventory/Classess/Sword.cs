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
        }

        public Sword(string name, string description, float weight)
        {
            Name = name;
            Description = description;
            Weight = weight;
        }
        
        public void Use()
        {
            Console.WriteLine("You use your {0} sword, which has {1} damage", Name, Damage);
        }
    }
}