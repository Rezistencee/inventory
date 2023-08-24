using System;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public static class InventoryManager
    {
        public static void AddItemToInventory(Inventory currentInventory, IItem item)
        {
            currentInventory.AddItem(item);
        }

        public static void RemoveItemFromInventory(Inventory currentInventory, IItem item)
        {
            throw new NotImplementedException();
        }

        public static void SearchItemInInventory(Inventory targetInventory, IItem searchItem)
        {
            throw new NotImplementedException();
        }
    }
}