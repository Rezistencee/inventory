using Inventory.Interfaces;

namespace Inventory.Classess
{
    //TODO: Consider as a replacement for stacking
    public class InventorySlot
    {
        private IItem _item;
        private int _quantity;

        public InventorySlot()
        {
            _item = null;
            _quantity = 0;
        }
        
        public InventorySlot(IItem item, int quantity)
        {
            _item = item;
            _quantity = quantity;
        }
    }
}