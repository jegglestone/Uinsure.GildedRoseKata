using GildedRoseKata;
using System.Diagnostics.Contracts;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void Foo()
    {
        List<Item> items = [ new Item { Name = "foo", SellInDays = 0, Quality = 0 } ];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }

    [Fact]
    public void EachDayNormalItemDecreasesInQuality()
    {
        List<Item> items = [new Item { Name = "Normal Item", SellInDays = 5, Quality = 10 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(9, items[0].Quality);
    }

    [Fact]
    public void EachDayNormalItemDecreasesSellInDays()
    {
        List<Item> items = [new Item { Name = "Normal Item", SellInDays = 5, Quality = 10 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(4, items[0].SellInDays);
    }
}
