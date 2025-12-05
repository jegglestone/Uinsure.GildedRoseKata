namespace GildedRose;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        List<Item> Items =
        [
            new Item { Name = "+5 Dexterity Vest", SellInDays = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellInDays = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellInDays = 5, Quality = 7 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellInDays = 0, Quality = 80 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellInDays = -1, Quality = 80 },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellInDays = 15,
                Quality = 20
            },

            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellInDays = 10,
                Quality = 49
            },

            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellInDays = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet

            new Item { Name = "Conjured Mana Cake", SellInDays = 3, Quality = 6 }
        ];

        var app = new GildedRose(Items);

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < Items.Count; j++)
            {
                Console.WriteLine(Items[j].Name + ", " + Items[j].SellInDays + ", " + Items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}
