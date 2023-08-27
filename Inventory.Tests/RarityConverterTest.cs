using System;
using Inventory.Converters;
using Inventory.Enums;
using NUnit.Framework;

namespace Inventory.Tests
{
    [TestFixture]
    public class RarityConverterTest
    {
        [Test]
        public void ConverterTestLegendaryExpected()
        {
            var expected = Rarity.Legendary;

            var actual = RarityConverter.Convert(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConverterTestMythicalExpected()
        {
            var expected = Rarity.Mythical;

            var actual = RarityConverter.Convert(3);
            
            Assert.AreEqual(expected, actual);
        }
    }
}