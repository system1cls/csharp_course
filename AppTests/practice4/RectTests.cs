using App.practice4;

namespace AppTests.practice4;

public class RectTests
{
    [Test]
    public void test1()
    {
        Rectangle rectangle = new Rectangle(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(3, 2),
            new MyVertex(3, 1)
        );

        Assert.That(rectangle.CalculateArea(), Is.EqualTo(2.0));
    }



    [Test]
    public void test2()
    {
        Rectangle rectangle = new Rectangle(
            new MyVertex(2, 1),
            new MyVertex(1, 2),
            new MyVertex(3, 4),
            new MyVertex(4, 3)
        );


        var TOLERANCE = 0.00000001;
        Assert.True(Math.Abs(rectangle.CalculateArea() - 4.0) < TOLERANCE);
    }

    [Test]
    public void test3()
    {
        Rectangle rectangle = new Rectangle(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(3, 2),
            new MyVertex(3.2, 1)
        );
        
        Assert.Catch<WrongParamsException>(() => rectangle.CalculateArea());
    }


    [Test]
    public void test4()
    {
        Rectangle rectangle = new Rectangle(
            new MyVertex(1, 1),
            new MyVertex(1, 2),
            new MyVertex(3, 2),
            new MyVertex(3, 3)
        );

        Assert.Catch<WrongParamsException>(() => rectangle.CalculateArea());
    }
}