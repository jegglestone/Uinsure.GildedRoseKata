namespace GildedRose.Strategies;

internal class AgedBrieUpdateStrategy : BaseQualityUpdaterStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        DecrementSellInDaysByOneDay(item);

        if (item.SellInDays < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
