namespace GildedRose.Strategies
{
    internal class ConjuredUpdateStrategy : BaseQualityUpdaterStrategy
    {
        public override void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = Math.Max(0, item.Quality - 2);
            }

            DecrementSellInDaysByOneDay(item);

            if (item.SellInDays < 0 && item.Quality > 0)
            {
                item.Quality = Math.Max(0, item.Quality - 2);
            }
        }
    }
}
