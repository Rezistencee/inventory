namespace Inventory.Interfaces
{
    public interface IConsumables
    {
        int StackableLimit { get; set; }
        int Quantity { get; set; }
    }
}