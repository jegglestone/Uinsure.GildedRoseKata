using GildedRose.Constants;
using GildedRose.Strategies;

namespace GildedRose;

public class GildedRoseInventoryUpdater(IList<Item> Items)
{
    private readonly IList<Item> Items = Items;

    public void UpdateQualityAndSellInDays()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];

            IQualityUpdaterStrategy strategy;

            if (item.Name == ItemNames.Sulfuras)
            {
                strategy = new SulfurasStrategy();
            }
            else if (item.Name == ItemNames.AgedBrie)
            {
                strategy = new AgedBrieUpdateStrategy();
            }
            else if (item.Name == ItemNames.BackstagePasses)
            {
                strategy = new BackstagePassesUpdateStrategy();
            }
            else 
            {
                strategy = new NormalItemUpdateStrategy();
            }

            strategy.UpdateQuality(Items[i]);
        }
    }
}
