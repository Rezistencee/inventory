using System;
using System.IO;
using Inventory.Classess;
using Inventory.Deserializers;
using Inventory.Enums;
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
                Sword factoryItem = new Sword(String.Format("Sword #{0}", item), "Something desc..", 1.5f, 12, Rarity.Epic);
                
                factoryItem.Weight = (float)(rand.Next(50, 100) / 10.0);
                factoryItem.Damage = rand.Next(1, 10);
                
                InventoryManager.AddItemToInventory(playerInventory, factoryItem);
            }

            HealingPotion healingPotion = new HealingPotion("Small healing potion", "Recover your HP", 0.8f, 50);
            playerInventory.AddItem(healingPotion);
            
            healingPotion = new HealingPotion("Big healing potion", "Recover your HP", 1f, 125);

            InventoryManager.AddItemToInventory(playerInventory, healingPotion);

            Crossbow crossbow = new Crossbow("Elf Crossbow", "Something desc...", 3.45f, 15, Rarity.Epic);
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

            InventoryManager.RemoveItemFromInventory(playerInventory, crossbow);
            
            Console.WriteLine("Current inventory weight: {0:F1}", playerInventory.Weight);
            
            InventoryManager.SearchItemInInventory(playerInventory, item => item.Name == "Elf Crossbow");
            
            InventoryManager.AddItemToInventory(playerInventory, crossbow);
            
            InventoryManager.SearchItemInInventory(playerInventory, item => item.Name == "Elf Crossbow");
            InventoryManager.SearchItemInInventory(playerInventory, item => (item.Name == "Elf Crossbow" && item.Weight > 3.0f));
            
            Crossbow crossbow_2 = new Crossbow("Emperror Crossbow", "Something desc...", 4.2f, 21, 3);
            crossbow_2.Damage = 24;
            
            InventoryManager.SearchItemInInventory(playerInventory, item => item == crossbow_2);
            
            Console.WriteLine("Inventory slots testing:");

            Classess.Inventory inventoryWithSlots = new Classess.Inventory();
            
            InventoryManager.AddItemToInventory(inventoryWithSlots, crossbow);
            InventoryManager.AddItemToInventory(inventoryWithSlots, crossbow_2);
            InventoryManager.AddItemToInventory(inventoryWithSlots, healingPotion);
            InventoryManager.AddItemToInventory(inventoryWithSlots, healingPotion);
            InventoryManager.AddItemToInventory(inventoryWithSlots, healingPotion);
            InventoryManager.AddItemToInventory(inventoryWithSlots, healingPotion);
            
            Console.WriteLine(inventoryWithSlots.Weight);
            
            foreach (var slot in inventoryWithSlots.GetInventorySlots())
            {
                Console.WriteLine("Item {0} with {1} quantity", slot.Item.Name, slot.Quantity);
            }
            
            InventoryManager.SearchItemInInventory(inventoryWithSlots, item => item == crossbow_2);
            
            Console.WriteLine("Json deserializer test:");
            
            JsonDeserializer<Crossbow>.DeserializeAndPrintCrossbows();
            
            Console.WriteLine("XML deserializer test:");
            Crossbow[] crossbows = XmlDeserializer<Crossbow>.DeserializeAll(Path.Combine(Directory.GetCurrentDirectory(), "items/crossbows"));
            HealingPotion[] healingPotions = XmlDeserializer<HealingPotion>.DeserializeAll(Path.Combine(Directory.GetCurrentDirectory(), "items/potions"));
            
            foreach (var item in crossbows)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Weight: {item.Weight}");
                Console.WriteLine($"Rarity: {item.Rarity}");
                Console.WriteLine($"Damage: {item.Damage}");
                Console.WriteLine($"Range: {item.Range}");
                Console.WriteLine();
            }
            
            foreach (var item in healingPotions)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Weight: {item.Weight}");
                Console.WriteLine($"Rarity: {item.Rarity}");
                Console.WriteLine($"Regeneration value: {item.RegenerationValue}");
                Console.WriteLine($"Stackable limit: {item.StackableLimit}");
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}