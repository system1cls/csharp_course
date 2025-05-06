namespace App.practice4;

/*
 * V2------V3
 * -       -
 * -       -
 * V1------V4
 */

public class Square : Rectangle
{
    
    public Square(I2DVertex V1, I2DVertex V2, I2DVertex V3, I2DVertex V4) : base(V1, V2, V3, V4)
    {
        var TOLERANCE = 0.0001;
        if (Math.Abs(GetDistance(V1, V4) - GetDistance(V1, V2)) > TOLERANCE) throw new WrongParamsException();
    }
}