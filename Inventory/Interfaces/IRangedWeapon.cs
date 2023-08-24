namespace Inventory.Interfaces
{
    public interface IRangedWeapon
    {
        int Range { get; set; }

        void Fire(int distance);
    }
}