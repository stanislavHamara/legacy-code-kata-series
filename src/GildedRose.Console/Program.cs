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
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
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
                if (item.Name == "Aged Brie")
                {
                    UpdateAgeingItem(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateDesirableEventItem(item);
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateLegendaryItem(item);
                }
                else
                {
                    UpdatePerishableItem(item);
                }
            }
        }

        private static void UpdateAgeingItem(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.IncreaseQuality();
            }
        }

        private static void UpdateDesirableEventItem(Item item)
        {
            // Tickets are more valuable when an event is closer
            if (item.SellIn <= 10)
            {
                item.IncreaseQuality();
            }

            // They increase in value much more the closer we are to the event
            if (item.SellIn <= 5)
            {
                item.IncreaseQuality();
            }

            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.Quality = 0;
            }
        }

        private static void UpdateLegendaryItem(Item item)
        {
        }

        private static void UpdatePerishableItem(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.DecreaseQuality();
            }
        }
    }
}