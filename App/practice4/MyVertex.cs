namespace App.practice4;

public class MyVertex : I2DVertex
{
    public double X { get; set; }
    public double Y { get; set; }

    public MyVertex(double x, double y)
    {
        X = x;
        Y = y;
    }
}