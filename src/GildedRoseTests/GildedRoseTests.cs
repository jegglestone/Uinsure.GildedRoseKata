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

    [Fact]
    public void NormalItemDegradesTwiceAsFastAfterSellIn()
    {
        List<Item> items = [new Item { Name = "Normal Item", SellInDays = 0, Quality = 10 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(8, items[0].Quality);
    }

    [Theory]
    [InlineData("Normal Item")]
    [InlineData("Aged Brie")]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    public void QualityNeverNegative(string itemName)
    {
        List<Item> items = [new Item { Name = itemName, SellInDays = 5, Quality = 0 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.True(items[0].Quality >= 0);
    }

    [Fact]
    public void SulfurasNeverHaveToBeSoldOrDecreaseInQuality()
    {
        List<Item> items = [new Item { Name = "Sulfuras, Hand of Ragnaros", SellInDays = 0, Quality = 80 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(0, items[0].SellInDays);
    }

    [Fact]
    public void BackstagePassesIncreaseInQuality()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 10, Quality = 20 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(22, items[0].Quality);
    }

    [Fact]
    public void BackstagePassesIncreaseInQualityBy2WhenThereAre10SellInDaysLeft()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 10, Quality = 30 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(32, items[0].Quality);
    }

    [Fact]
    public void BackstagePassesIncreaseInQualityBy2WhenThereAreLessThan10SellInDaysLeft()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 8, Quality = 30 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(32, items[0].Quality);
    }

    [Fact]
    public void BackstagePassesIncreaseInQualityBy3WhenThereAre5SellInDaysLeft()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 5, Quality = 30 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(33, items[0].Quality);
    }

    [Fact]
    public void BackstagePassesIncreaseInQualityBy3WhenThereAreLessThan5SellInDaysLeft()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 4, Quality = 30 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(33, items[0].Quality);
    }

    [Fact]
    public void BackstagePassesQualityDropsToZeroAfterConcert()
    {
        List<Item> items = [new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellInDays = 0, Quality = 20 }];
        GildedRose app = new(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }
}
