using App.practice4;

namespace AppTests.practice4;

public class TriangleTests
{
    [Test]
    public void test1()
    {
        IGeometry triangle = new Triangle(
            new MyVertex(1, 1),
            new MyVertex(2, 2),
            new MyVertex(3, 1)
        );
        
        Assert.AreEqual(triangle.CalculateArea(), 1.0);
    }

    [Test]
    public void test2()
    {
        IGeometry triangle = new Triangle(
            new MyVertex(1, 1),
            new MyVertex(1, 5),
            new MyVertex(3, 1)
        );
        
        Assert.AreEqual(triangle.CalculateArea(), 4.0);
    }
    
}