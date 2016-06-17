namespace GildedRose.Console
{
    class DesirableEventItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            UpdateDesirableEventItem(item);
        }

        public static void UpdateDesirableEventItem(Item item)
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
    }
}