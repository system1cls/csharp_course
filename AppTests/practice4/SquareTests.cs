using App.practice4;

namespace AppTests.practice4;

public class SquareTests
{
    [Test]
    public void TestSquare1()
    {
        IGeometry square = new Square(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(2, 2),
            new MyVertex(2, 1)
        );

        Assert.That(1, Is.EqualTo(square.CalculateArea()));
    }



    [Test]
    public void TestSquare2()
    {
        Assert.Catch<WrongParamsException>(() => new Square(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(3, 2),
            new MyVertex(3, 1)
            ));

    }
}