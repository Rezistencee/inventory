namespace Inventory.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        float Weight { get; set; }

        void Use();
    }
}