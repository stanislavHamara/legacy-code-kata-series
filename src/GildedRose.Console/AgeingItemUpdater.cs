namespace GildedRose.Console
{
    class AgeingItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            UpdateAgeingItem(item);
        }

        public static void UpdateAgeingItem(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();

            if (item.HasPassedSellByDate())
            {
                item.IncreaseQuality();
            }
        }
    }
}