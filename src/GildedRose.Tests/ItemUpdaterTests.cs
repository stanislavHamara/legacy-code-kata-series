using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
    {
        [Test]
        public void StandardItemShouldLowerQualityAndSellInByOne()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 3, Quality = 6 };

            Program.UpdateItem(item);

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void StandardItemShouldLowerQualityTwiceAsFastWhenSellInIsNegative()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -2, Quality = 6 };

            Program.UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void StandardItemShouldLowerQualityTwiceAsFastWhenSellInIsZero()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 6 };

            Program.UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
    }
}