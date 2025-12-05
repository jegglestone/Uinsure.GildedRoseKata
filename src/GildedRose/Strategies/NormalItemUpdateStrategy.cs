namespace GildedRose.Strategies;

internal class NormalItemUpdateStrategy : BaseQualityUpdaterStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        DecrementSellInDaysByOneDay(item);

        if (item.SellInDays < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }              
        }
    }
}