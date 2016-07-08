using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ItemUpdaterTests
    {
        [Test]
        public void StandardItemShouldLowerQualityAndSellInByOne()
        {
            var item = new Item( name: "+5 Dexterity Vest", sellIn: 3, quality: 6, itemType: ItemType.PerishableItem);

            UpdateItem(item);

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void StandardItemShouldLowerQualityTwiceAsFastWhenSellInIsNegative()
        {
            var item = new Item( name: "+5 Dexterity Vest", sellIn: -2, quality: 6, itemType: ItemType.PerishableItem);

            UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
        }

        [Test]
        public void StandardItemShouldLowerQualityTwiceAsFastWhenSellInIsZero()
        {
            var item = new Item( name: "+5 Dexterity Vest", sellIn: 0, quality: 6, itemType: ItemType.PerishableItem);

            UpdateItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldIncreaseQualityTwiceAsFastWhenSellInLessThanElevenDays()
        {
            var item = new Item( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 6, itemType: ItemType.DesirableEventItem );

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldIncreaseQualityThreeTimesAsFastWhenSellInLessThanSixDays()
        {
            var item = new Item( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 6, itemType: ItemType.DesirableEventItem);

            UpdateItem(item);

            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void BackstagePassItemShouldHaveZeroQualityWhenSellInBelowZero()
        {
            var item = new Item( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 6, itemType: ItemType.DesirableEventItem);

            UpdateItem(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgedBrieQualityIncreasesTwiceAsFastWhenSellInIsLessThanZero()
        {
            var item = new Item( name: "Aged Brie", sellIn: 0, quality: 6, itemType: ItemType.AgingItem);

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void StandardItemQualityIsNeverNegative()
        {
            var item = new Item( name: "+5 Dexterity Vest", sellIn: 10, quality: 0, itemType: ItemType.PerishableItem);

            UpdateItem(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void SulfurasNeverDecreasesInQualityAndNeverHasToBeSold()
        {
            var item = new Item( name: "Sulfuras, Hand of Ragnaros", sellIn: 10, quality: 80, itemType: ItemType.LegendaryItem);

            UpdateItem(item);

            Assert.AreEqual(80, item.Quality);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void AgedBrieQualityCanNeverBeMoreThanFifty()
        {
            var item = new Item( name: "Aged Brie", sellIn: -1, quality: 50, itemType: ItemType.AgingItem);

            UpdateItem(item);

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        [Test]
        public void ConjuredManaCakeQualityDecreasesTwiceAsFast()
        {
            var item = new Item( name: "Conjured Mana Cake", sellIn: 6, quality: 10 , itemType: ItemType.ConjuredItem);

            UpdateItem(item);

            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(5, item.SellIn);
        }

        private void UpdateItem(Item item)
        {
            Program.UpdateQuality(new[] { item });
        }
    }
}