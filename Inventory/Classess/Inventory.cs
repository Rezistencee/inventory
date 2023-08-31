using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Inventory
    {
        private List<IItem> _items;
        private List<InventorySlot> _slots;
        private readonly float _maxWeight;
        private float _currentWeight;

        public float MaxWeight
        {
            get
            {
                return _maxWeight;
            }
        }
        
        public float Weight
        {
            get
            {
                return _currentWeight;
            }
        }
        
        public event Action<IItem> ItemAdded;

        public Inventory()
        {
            _items = new List<IItem>();
            _slots = new List<InventorySlot>(12);
            _maxWeight = 100.0f;
            _currentWeight = 0.0f;
        }

        public void AddItem(IItem item)
        {
            _items.Add(item);
            _currentWeight += item.Weight;
            OnItemAdded(item);
        }
        
        public void SlotAddItem(IItem item)
        {
            foreach (InventorySlot inventorySlot in _slots)
            {
                if (inventorySlot.Item == item)
                {
                    if (inventorySlot.CanStackable)
                    {
                        inventorySlot.AddStackableItem(item);
                        _currentWeight += item.Weight;
                        return;
                    }
                }
            }

            InventorySlot tempSlot = new InventorySlot(item);
            
            _slots.Add(tempSlot); 
            _currentWeight += item.Weight;
        }

        public void RemoveItem(IItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                _currentWeight -= item.Weight;
            }
        }

        public IEnumerable<IItem> GetInventory()
        {
            return _items;
        }

        public IEnumerable<InventorySlot> GetInventorySlots()
        {
            return _slots;
        }
        
        protected virtual void OnItemAdded(IItem item)
        {
            ItemAdded?.Invoke(item);
        }
    }
}