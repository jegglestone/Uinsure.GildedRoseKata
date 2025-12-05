using GildedRose.Factory;

namespace GildedRose;

public class GildedRoseInventoryUpdater(IList<Item> Items)
{
    private readonly IList<Item> Items = Items;

    public void UpdateQualityAndSellInDays()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];

            var strategy = QualityUpdaterStrategyFactory.GetQualityUpdaterStrategy(item.Name);

            strategy.UpdateQuality(Items[i]);
        }
    }
}
