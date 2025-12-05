using GildedRose.Constants;

namespace GildedRose.Strategies;

internal class NormalItemUpdateStrategy : IQualityUpdaterStrategy
{
    public int UpdateQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellInDays = item.SellInDays - 1;

        if (item.SellInDays < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }              
        }

        return item.Quality;
    }
}