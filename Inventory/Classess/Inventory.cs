using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Inventory
    {
        private List<IItem> _items;
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

        public Inventory()
        {
            _items = new List<IItem>();
            _maxWeight = 100.0f;
            _currentWeight = 0.0f;
        }

        public void AddItem(IItem item)
        {
            _items.Add(item);
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
    }
}