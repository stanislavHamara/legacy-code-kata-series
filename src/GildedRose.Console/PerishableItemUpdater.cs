namespace GildedRose.Console
{
    class PerishableItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            UpdatePerishableItem(item);
        }

        public static void UpdatePerishableItem(Item item)
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