using System;
using Inventory.Classess;

namespace Inventory
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Classess.Inventory playerInventory = new Classess.Inventory();
            Random rand = new Random();

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
            
            var inventory = playerInventory.GetInventory();

            foreach (var item in inventory)
            {
                item.Use();
            }
        }
    }
}