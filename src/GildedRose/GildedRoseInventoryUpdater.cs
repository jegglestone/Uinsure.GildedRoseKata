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

            if (item.Name == ItemNames.Sulfuras)
            {
                var sulfurasStrategy = new SulfurasStrategy();
                sulfurasStrategy.UpdateQuality(Items[i]);
                continue;
            }
            else if (item.Name == ItemNames.AgedBrie)
            {
                var agedBrieStrategy = new AgedBrieUpdateStrategy();
                agedBrieStrategy.UpdateQuality(Items[i]);
                continue;
            }
            else if (item.Name == ItemNames.BackstagePasses)
            {
                var backStagePassesStrategy = new BackstagePassesUpdateStrategy();
                backStagePassesStrategy.UpdateQuality(Items[i]);
                continue;
            }
            else 
            {
                var normalItemStrategy = new NormalItemUpdateStrategy();
                normalItemStrategy.UpdateQuality(Items[i]);
                continue;
            }
        }
    }
}
