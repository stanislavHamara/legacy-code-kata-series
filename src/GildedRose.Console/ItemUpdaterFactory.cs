using System;

namespace GildedRose.Console
{
    static class ItemUpdaterFactory
    {
        public static IItemUpdater CreateItemUpdater(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Legendary:
                    return new LegendaryItemUpdater();
                case ItemType.Perishable:
                    return new PerishableItemUpdater();
                case ItemType.Ageing:
                    return new AgeingItemUpdater();
                case ItemType.DesirableEvent:
                    return new DesirableEventItemUpdater();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}