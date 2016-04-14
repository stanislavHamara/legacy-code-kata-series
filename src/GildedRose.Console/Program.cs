using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    internal class Program
    {
        private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieName = "Aged Brie";
        private const string SulfurasHandOfRagnarosName = "Sulfuras, Hand of Ragnaros";
        private const string DexterityVestName = "+5 Dexterity Vest";
        private const string ElixirOfTheMongooseName = "Elixir of the Mongoose";
        private const string ConjuredManaCakeName = "Conjured Mana Cake";
        private const int MaxQualityForNormalItems = 50;
        private const int MinimumQuality = 0;

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
                    new Item {Name = DexterityVestName, SellIn = 10, Quality = 20},
                    new Item {Name = AgedBrieName, SellIn = 2, Quality = MinimumQuality},
                    new Item {Name = ElixirOfTheMongooseName, SellIn = 5, Quality = 7},
                    new Item {Name = SulfurasHandOfRagnarosName, SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = BackstagePassName,
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = ConjuredManaCakeName, SellIn = 3, Quality = 6}
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
            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];

                switch (item.Name)
                {
                    case AgedBrieName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    case BackstagePassName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    case SulfurasHandOfRagnarosName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    case DexterityVestName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    case ElixirOfTheMongooseName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    case ConjuredManaCakeName:
                    {
                        UpdateQuality(item);
                        break;
                    }
                    default:
                    {
                        throw new Exception("Unknown item");
                    }
                }
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name == AgedBrieName || item.Name == BackstagePassName)
            {
                IncreaseQualityWithinLimit(item);

                if (item.Name == BackstagePassName)
                {
                    if (InsideTicketBonusPeriod(item))
                    {
                        IncreaseQualityWithinLimit(item);
                    }

                    if (InsideTicketSecondBonusPeriod(item))
                    {
                        IncreaseQualityWithinLimit(item);
                    }
                }
            }
            else
            {
                if (item.Name != SulfurasHandOfRagnarosName)
                {
                    DecreaseQualityWithinLimit(item);
                }
            }

            if (item.Name != SulfurasHandOfRagnarosName)
            {
                DecreaseSellIn(item);
            }

            if (HasExpired(item))
            {
                if (item.Name == AgedBrieName)
                {
                    IncreaseQualityWithinLimit(item);
                }
                else
                {
                    if (item.Name == BackstagePassName)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        if (item.Name != SulfurasHandOfRagnarosName)
                        {
                            DecreaseQualityWithinLimit(item);
                        }
                    }
                }
            }
        }

        private static void DecreaseQualityWithinLimit(Item item)
        {
            if (item.Quality > MinimumQuality)
            {
                DecreaseQuality(item);
            }
        }

        private static void IncreaseQualityWithinLimit(Item item)
        {
            if (CanIncreaseQuality(item))
            {
                IncreaseQuality(item);
            }
        }

        private static bool CanIncreaseQuality(Item item)
        {
            return item.Quality < MaxQualityForNormalItems;
        }

        private static bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private static bool InsideTicketSecondBonusPeriod(Item item)
        {
            return item.SellIn < 6;
        }

        private static bool InsideTicketBonusPeriod(Item item)
        {
            return item.SellIn < 11;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}