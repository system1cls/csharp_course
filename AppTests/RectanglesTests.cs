using App;

namespace AppTests;

public class RectanglesTests
{
    
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, true)]
    [TestCase(0, 0, 1, 1, 2, 2, 3, 3, false)]
    [TestCase(0, 0, 1, 1, 1, 0, 2, 2, true)]
    [TestCase(1, 1, 2, 2, 0, 0, 1, 1, true)]
    [TestCase(0, 0, 3, 3, 1, 2, 2, 4, true)]
    [TestCase(2, 2, 4, 4, 0, 0, 3, 3, true)]
    public void TestPasses_When_IsIntersectedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsIntersected(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    
    [TestCase(0, 0, 3, 3, 1, 1, 2, 2, true)] 
    [TestCase(0, 0, 1, 1, 1, 1, 2, 2, false)]
    [TestCase(0, 0, 1, 1, 0, 0, 1, 1, true)]
    [TestCase(1, 1, 2, 2, 0, 0, 3, 3, true)]
    public void TestPasses_WhenIsNestedResult_Correct(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4,
        bool expected)
    {
        var actual = Rectangles.IsNested(x1, y1, x2, y2, x3, y3, x4, y4);
        Assert.That(actual, Is.EqualTo(expected));
    }
}