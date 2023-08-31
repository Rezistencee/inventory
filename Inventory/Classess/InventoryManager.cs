using System;
using System.Linq;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public static class InventoryManager
    {
        /*public static void AddItemToInventory(Inventory currentInventory, IItem item)
        {
            if(currentInventory.Weight + item.Weight <= currentInventory.MaxWeight) {
                currentInventory.AddItem(item);
            }
            else
            {
                Console.WriteLine("Unable to put item in inventory, maximum weight reached");
            }
        }*/
        
        public static void AddItemToInventory(Inventory currentInventory, IItem item)
        {
            if(currentInventory.Weight + item.Weight <= currentInventory.MaxWeight) {
                currentInventory.SlotAddItem(item);
            }
            else
            {
                Console.WriteLine("Unable to put item in inventory, maximum weight reached");
            }
        }
        
        //TODO: Try to refactoring this method.
        public static void RemoveItemFromInventory(Inventory currentInventory, IItem item)
        {
            if (currentInventory.GetInventory().Contains(item))
                currentInventory.RemoveItem(item);
            else
                Console.WriteLine("Item not found in inventory.");
        }
        
        //TODO: Try to refactoring this method.
        /*
        public static void SearchItemInInventory(Inventory targetInventory, Func<IItem, bool> searchPredicate)
        {
            foreach (IItem item in targetInventory.GetInventory())
            {
                if (searchPredicate(item))
                {
                    Console.WriteLine("Item found in inventory.");
                    return;
                }
            }

            Console.WriteLine("Item not found in inventory.");
        }*/
        
        public static void SearchItemInInventory(Inventory targetInventory, Func<IItem, bool> searchPredicate)
        {
            foreach (var slot in targetInventory.GetInventorySlots())
            {
                if (searchPredicate(slot.Item))
                {
                    Console.WriteLine("Item found in inventory.");
                    return;
                }
            }

            Console.WriteLine("Item not found in inventory.");
        }
    }
}