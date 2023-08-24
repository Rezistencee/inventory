using System;
using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Inventory
    {
        private List<IItem> _items;
        private float _maxWeight;
        private float _currentWeight;

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
            if(_currentWeight + item.Weight <= _maxWeight) {
                _items.Add(item);
                _currentWeight += item.Weight;
            }
            else
            {
                Console.WriteLine("Unable to put item in inventory, maximum weight reached");
            }
        }

        public IEnumerable<IItem> GetInventory()
        {
            return _items;
        }
    }
}