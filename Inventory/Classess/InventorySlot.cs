using Inventory.Interfaces;

namespace Inventory.Classess
{
    //TODO: Consider as a replacement for stacking
    public class InventorySlot
    {
        private static int _id = 1;
        private IItem _item;
        private int _quantity;
        private int _stackableLimit;

        public IItem Item
        {
            get
            {
                return _item;
            }
        }

        public InventorySlot()
        {
            _item = null;
            _quantity = 0;
            _id = _id + 1;
            _stackableLimit = 1;
        }
        
        public InventorySlot(IItem item, int quantity)
        {
            _item = item;
            _quantity = quantity;
            _id = _id + 1;

            if (item is IConsumables consumablesItem)
                _stackableLimit = consumablesItem.StackableLimit;
            else
                _stackableLimit = 1;
        }
    }
}