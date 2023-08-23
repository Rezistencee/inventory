using System.Collections;
using System.Collections.Generic;

namespace Inventory.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems();
        void AddToStorage(T item);
    }
}