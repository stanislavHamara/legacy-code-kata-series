using System;

namespace GildedRose.Console
{
    public class Item
    {
        public Item(string name, int sellIn, int quality, ItemType itemType)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            ItemType = itemType;
        }

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Unspecified,
        AgingItem,
        DesirableEventItem,
        ConjuredItem,
        PerishableItem,
        LegendaryItem
    }
}