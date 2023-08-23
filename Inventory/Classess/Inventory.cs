using System.Collections.Generic;
using Inventory.Interfaces;

namespace Inventory.Classess
{
    public class Inventory
    {
        private List<IItem> _items;

        public Inventory()
        {
            _items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<IItem> GetInventory()
        {
            return _items;
        }
    }
}