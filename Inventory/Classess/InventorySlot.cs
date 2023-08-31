using System;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    //TODO: Consider as a replacement for stacking
    public class InventorySlot
    {
        private static int _id = 1;
        private IItem _item;
        private int _quantity;
        private readonly int _stackableLimit;

        public IItem Item
        {
            get
            {
                return _item;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public bool CanStackable
        {
            get
            {
                return (_quantity < _stackableLimit) ? true : false;
            }
        }

        public InventorySlot()
        {
            _item = null;
            _quantity = 0;
            _id = _id + 1;
            _stackableLimit = 1;
        }
        
        public InventorySlot(IItem item)
        {
            _item = item;
            _quantity = 1;
            _id = _id + 1;

            if (item is IConsumables consumablesItem)
                _stackableLimit = consumablesItem.StackableLimit;
            else
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

        public void AddStackableItem(IItem item)
        {
            if (CanStackable)
                _quantity++;
            else
                throw new IndexOutOfRangeException();
        }
    }
}