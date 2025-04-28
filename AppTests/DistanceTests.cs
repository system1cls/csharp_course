using App;

namespace AppTests;

public class DistanceTests
{
 
    [TestCase(1, 1, 0, 0, 2, 0, 1)]
    [TestCase(1, 1, 1, 1, 1, 1, 0)]
    [TestCase(1, 1, 0, 0, 0, 2, 1)]
    [TestCase(1, 1, 0, 0, 2, 2, 0)]
    [TestCase(1, 0, 0, 0, 2, 2, 0.70710678118654746d)]
    [TestCase(2, 1, 0, 0, 1, 0, 1.4142135623730951d)]
    [TestCase(0, 0, 1, 1, 2, 2, 1.4142135623730951d)]
    public void TestPasses_When_Result_Correct(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2,
        double expected)
    {
        var actual = Distance.DistanceToSegment(x, y, x1, y1, x2, y2);
        Assert.That(actual, Is.EqualTo(expected));
    }
}