using System;
using Inventory.Enums;

namespace Inventory.Converters
{
    public static class RarityConverter
    {
        public static Rarity Convert(int inputValue)
        {
            if (inputValue == null)
            {
                throw new ArgumentNullException(nameof(inputValue));
            }

            if (Enum.IsDefined(typeof(Rarity), inputValue))
            {
                return (Rarity)inputValue;
            }

            throw new ArgumentException("Invalid value for Rarity enum");
        }
    }
}