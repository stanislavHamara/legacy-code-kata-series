using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        private IList<Item> Items;

        internal static void Main(string[] args)
        {
            UpdateAndPrintItems();

            System.Console.ReadKey();
        }

        internal static void UpdateAndPrintItems()
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                Items = new List<Item>
                {
                    new Item (name: "+5 Dexterity Vest", sellIn: 10, quality: 20, itemType: ItemType.PerishableItem),
                    new Item (name: "Aged Brie", sellIn: 2, quality: 0, itemType: ItemType.AgingItem),
                    new Item (name: "Elixir of the Mongoose", sellIn: 5, quality: 7, itemType: ItemType.PerishableItem),
                    new Item (name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80, itemType: ItemType.LegendaryItem),
                    new Item
                    (
                        name: "Backstage passes to a TAFKAL80ETC concert",
                        sellIn: 15,
                        quality: 20,
                        itemType: ItemType.DesirableEventItem
                    ),
                    new Item (name: "Conjured Mana Cake", sellIn: 3, quality: 6, itemType: ItemType.ConjuredItem),
                    new Item (name: "Merlot Red Wine", sellIn: 3, quality: 9, itemType: ItemType.AgingItem),
                    new Item (name: "Stilton", sellIn: 3, quality: 9, itemType: ItemType.AgingItem),
                    new Item (name: "Gruyere Cheese", sellIn: 3, quality: 9, itemType: ItemType.AgingItem),
                    new Item (name: "Cuban Cigars", sellIn: 3, quality: 9, itemType: ItemType.LegendaryItem),
                    new Item (name: "Artichoke", sellIn: 5, quality: 9, itemType: ItemType.PerishableItem),
                    new Item (name: "Yoghurt", sellIn: 10, quality: 9, itemType: ItemType.PerishableItem),
                    new Item (name: "Gourmet Dinner Tickets", sellIn: 10, quality: 9, itemType: ItemType.DesirableEventItem),
                    new Item (name: "Wine Tasting Workshop", sellIn: 42, quality: 9, itemType: ItemType.DesirableEventItem),
                }
            };

            app.UpdateQuality();

            PrintItems(app);
        }

        private static void PrintItems(Program app)
        {
            foreach (var item in app.Items)
            {
                System.Console.WriteLine("{0}|{1}|{2}", item.Name, item.Quality, item.SellIn);
            }
        }

        public void UpdateQuality()
        {
            UpdateQuality(Items.ToArray());
        }

        public static void UpdateQuality(Item[] items)
        {
            foreach (var item in items)
            {
                switch (item.ItemType)
                {
                    case ItemType.AgingItem:
                        UpdateAgeingItem(item);
                        break;
                    case ItemType.ConjuredItem:
                        UpdateConjuredItem(item);
                        break;
                    case ItemType.DesirableEventItem:
                        UpdateDesirableEventItem(item);
                        break;
                    case ItemType.LegendaryItem:
                        UpdateLegendaryItem(item);
                        break;
                    case ItemType.PerishableItem:
                        UpdatePerishableItem(item);
                        break;
                    default:
                        throw new InvalidOperationException($"Cannot update quality for item type {item.ItemType}");

                }
            }
        }

        private static void UpdateConjuredItem(Item item)
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
            DecreaseSellIn(item);
        }

        private static void UpdateAgeingItem(Item item)
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (HasPassedSellByDate(item))
            {
                IncreaseQuality(item);
            }
        }

        private static void UpdateDesirableEventItem(Item item)
        {
            // Tickets are more valuable when an event is closer
            if (item.SellIn <= 10)
            {
                IncreaseQuality(item);
            }

            // They increase in value much more the closer we are to the event
            if (item.SellIn <= 5)
            {
                IncreaseQuality(item);
            }

            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (HasPassedSellByDate(item))
            {
                item.Quality = 0;
            }
        }

        private static void UpdateLegendaryItem(Item item)
        {
        }

        private static void UpdatePerishableItem(Item item)
        {
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (HasPassedSellByDate(item))
            {
                DecreaseQuality(item);
            }
        }

        private static bool HasPassedSellByDate(Item item)
        {
            return item.SellIn < 0;
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}