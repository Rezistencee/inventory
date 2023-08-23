using Inventory.Interfaces;

namespace Inventory.Classess
{
    public static class InventoryManager
    {
        public static void AddItemToInventory(Inventory currentInventory, IItem item)
        {
            currentInventory.AddItem(item);
        }
    }
}