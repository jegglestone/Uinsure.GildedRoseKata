namespace GildedRose.Strategies;

internal class BackstagePassesUpdateStrategy : BaseQualityUpdaterStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

            if (item.SellInDays < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

            if (item.SellInDays < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }

        DecrementSellInDaysByOneDay(item);

        if (item.SellInDays < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }
    }
}
