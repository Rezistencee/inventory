using System;
using Inventory.Classess;
using Inventory.Interfaces;

namespace Inventory
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Classess.Inventory playerInventory = new Classess.Inventory();
            Random rand = new Random();
            int rangedWeaponCount = 0;

            for (int item = 1; item <= 10; item++)
            {
                Sword factoryItem = new Sword(String.Format("Sword #{0}", item), "Something desc..", 1.5f);
                
                factoryItem.Weight = (float)(rand.Next(50, 100) / 10.0);
                factoryItem.Damage = rand.Next(1, 10);
                
                InventoryManager.AddItemToInventory(playerInventory, factoryItem);
            }

            HealingPotion healingPotion = new HealingPotion("Small healing potion", "Recover your HP", 0.8f, 50);
            playerInventory.AddItem(healingPotion);
            
            healingPotion = new HealingPotion("Big healing potion", "Recover your HP", 1f, 125);

            InventoryManager.AddItemToInventory(playerInventory, healingPotion);

            Crossbow crossbow = new Crossbow("Elf Crossbow", "Something desc...", 3.45f, 15);
            crossbow.Damage = 21;
            
            InventoryManager.AddItemToInventory(playerInventory, crossbow);
            
            var inventory = playerInventory.GetInventory();

            foreach (var item in inventory)
            {
                if (item is IRangedWeapon rangedWeapon)
                {
                    rangedWeapon.Fire(27);
                    rangedWeaponCount++;
                }

                item.Use();
            }
            
            Console.WriteLine("Ranged weapon count is {0}", rangedWeaponCount);
            
            Console.WriteLine("Current inventory weight: {0:F1}", playerInventory.Weight);
        }
    }
}