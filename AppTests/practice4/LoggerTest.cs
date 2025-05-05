using App.practice4;

namespace AppTests.practice4;

public class LoggerTest
{
    [Test]
    public void TestLogger()
    {

        IGeometry square = new Square(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(2, 2),
            new MyVertex(2, 1)
        );

        IGeometry rect = new Rectangle(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(2, 2),
            new MyVertex(2, 1)
        );

        IGeometry triangle = new Triangle(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(2, 1)
        );
        
        Logger logger = new Logger();
        
        Assert.That(logger.logGeometry(triangle).Equals("Треугольник"));
        Assert.That(logger.logGeometry(square).Equals("Квадрат"));
        Assert.That(logger.logGeometry(rect).Equals("Прямоугольник"));
    }
}