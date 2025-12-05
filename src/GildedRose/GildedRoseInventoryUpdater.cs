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

            if (item.Name == ItemNames.AgedBrie)
            {
                var agedBrieStrategy = new AgedBrieUpdateStrategy();
                item.Quality = agedBrieStrategy.UpdateQuality(Items[i]);

            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellInDays < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        if (item.SellInDays < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0 && item.Name != ItemNames.AgedBrie)
                {
                    item.Quality = item.Quality - 1;
                }
            }

            item.SellInDays = item.SellInDays - 1;

            if (item.SellInDays < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
                else
                {
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = item.Quality - item.Quality;
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
}
