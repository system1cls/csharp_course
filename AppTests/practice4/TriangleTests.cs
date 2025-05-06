using App.practice4;

namespace AppTests.practice4;

public class TriangleTests
{
    [Test]
    public void Test1()
    {
        IGeometry triangle = new Triangle(
            new MyVertex(1, 1),
            new MyVertex(2, 2),
            new MyVertex(3, 1)
        );
        
        Assert.That(1.0, Is.EqualTo(triangle.CalculateArea()));
    }

    [Test]
    public void Test2()
    {
        IGeometry triangle = new Triangle(
            new MyVertex(1, 1),
            new MyVertex(1, 5),
            new MyVertex(3, 1)
        );
        
        Assert.That(4.0, Is.EqualTo(triangle.CalculateArea()));
    }
    
}