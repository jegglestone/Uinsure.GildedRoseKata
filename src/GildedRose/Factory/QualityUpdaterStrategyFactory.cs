using GildedRose.Constants;
using GildedRose.Strategies;

namespace GildedRose.Factory
{
    internal class QualityUpdaterStrategyFactory
    {
        internal static IQualityUpdaterStrategy GetQualityUpdaterStrategy(string itemName)
        {
            return itemName switch
            {
                ItemNames.Sulfuras => new SulfurasStrategy(),
                ItemNames.AgedBrie => new AgedBrieUpdateStrategy(),
                ItemNames.BackstagePasses => new BackstagePassesUpdateStrategy(),
                _ => new NormalItemUpdateStrategy(),
            };
        }
    }
}
