namespace App.practice4;

public class MyVertex : I2DVertex
{
    public double X { get; set; }
    public double Y { get; set; }

    public override String ToString()
    {
        return "(x = " + X + ", y = " + Y + ")";
    }

}