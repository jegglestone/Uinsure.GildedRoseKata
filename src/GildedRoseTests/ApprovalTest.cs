using System.Text;
using GildedRose;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        var originalOut = Console.Out;
        var originalIn = Console.In;
        try
        {
            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new[] { "30" });

            var output = fakeOutput.ToString();

            return Verifier.Verify(output);
        }
        finally
        {
            Console.SetOut(originalOut);
            Console.SetIn(originalIn);
        }
    }
}