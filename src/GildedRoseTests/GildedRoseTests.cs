using GildedRoseKata;

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
}
