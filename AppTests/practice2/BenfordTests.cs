using App.practice2;

namespace AppTests.practice2;

public class BenfordTests
{
    [TestCase("12 23",  new int[] {0, 1, 1, 0, 0, 0, 0, 0, 0, 0})]

    public void BenfordTest(string text, int[] statistics)
    {
        int[] ans= Benford.GetBenfordStatistics(text);
        Assert.That(ans, Is.EquivalentTo(statistics));
    }
}