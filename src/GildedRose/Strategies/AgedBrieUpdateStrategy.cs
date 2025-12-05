using GildedRose.Constants;

namespace GildedRose.Strategies;

internal class AgedBrieUpdateStrategy : IQualityUpdaterStrategy
{
    public int UpdateQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        item.SellInDays = item.SellInDays - 1;

        if (item.SellInDays < 0)
        {
            if (item.Name == ItemNames.AgedBrie)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        return item.Quality;
    }
}
