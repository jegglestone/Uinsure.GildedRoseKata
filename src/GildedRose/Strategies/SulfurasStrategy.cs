namespace GildedRose.Strategies;

internal class SulfurasStrategy : IQualityUpdaterStrategy
{
    public int UpdateQuality(Item item)
    {
        return item.Quality;
    }
}
