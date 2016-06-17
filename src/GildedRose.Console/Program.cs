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
                    new Item {ItemType = ItemType.Perishable, Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {ItemType = ItemType.Ageing, Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {ItemType = ItemType.Perishable, Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {ItemType = ItemType.Legendary, Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        ItemType = ItemType.DesirableEvent,
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
                var itemUpdater = ItemUpdaterFactory.CreateItemUpdater(item.ItemType);
                itemUpdater.UpdateItem(item);
                
            }
        }
    }
}