using Inventory.Enums;

namespace Inventory.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        float Weight { get; set; }
        Rarity Rarity { get; set;  }

        void Use();
    }
}