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
        
        public static Rarity ConvertToRarity(string inputValue)
        {
            if (inputValue == null)
            {
                throw new ArgumentNullException(nameof(inputValue));
            }
            
            if (Enum.TryParse(inputValue, out Rarity rarity))
            {
                return rarity;
            }

            throw new ArgumentException("Invalid value for Rarity enum");
        }
    }
}