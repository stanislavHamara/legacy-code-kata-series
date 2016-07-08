using System;

namespace GildedRose.Console
{
    public class Item
    {
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