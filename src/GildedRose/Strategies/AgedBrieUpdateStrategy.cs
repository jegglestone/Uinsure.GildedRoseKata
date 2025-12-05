namespace GildedRose.Strategies;

internal class AgedBrieUpdateStrategy : IQualityUpdaterStrategy
{
    public int UpdateQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        return item.Quality;
    }
}
