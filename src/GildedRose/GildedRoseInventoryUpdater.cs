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
                item.Quality = agedBrieStrategy.UpdateQuality(Items[i]);
            }
            else if (item.Name == ItemNames.BackstagePasses)
            {
                var backStagePassesStrategy = new BackstagePassesUpdateStrategy();
                item.Quality = backStagePassesStrategy.UpdateQuality(Items[i]);
                continue;
            }
            else if (item.Quality > 0)
            {
                var normalItemStrategy = new NormalItemUpdateStrategy();
                normalItemStrategy.UpdateQuality(Items[i]);
                continue;
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
                else
                {

                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }

                }
            }
        }
    }
}
