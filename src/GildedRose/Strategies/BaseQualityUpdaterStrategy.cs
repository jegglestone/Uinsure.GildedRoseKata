namespace GildedRose.Strategies
{
    internal abstract class BaseQualityUpdaterStrategy : IQualityUpdaterStrategy
    {
        protected BaseQualityUpdaterStrategy() { }

        public abstract void UpdateQuality(Item item);

        protected static void DecrementSellInDaysByOneDay(Item item)
        {
            item.SellInDays -= 1;
        }
    }
}
