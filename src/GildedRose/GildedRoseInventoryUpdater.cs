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
            if (Items[i].Name == ItemNames.Sulfuras)
            {
                var sulfurasStrategy = new SulfurasStrategy();
                sulfurasStrategy.UpdateQuality(Items[i]);
                continue;
            }

            if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellInDays < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellInDays < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Items[i].Quality > 0)
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
            }

            Items[i].SellInDays = Items[i].SellInDays - 1;
            
            if (Items[i].SellInDays < 0)
            {
                if (Items[i].Name == "Aged Brie")
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
                else
                {
                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                    else
                    {
                        if (Items[i].Quality > 0)
                        {
                            Items[i].Quality = Items[i].Quality - 1;                            
                        }
                    }
                }
            }
        }
    }
}
