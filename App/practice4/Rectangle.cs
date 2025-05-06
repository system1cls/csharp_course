namespace App.practice4;





/*
 *
 * V2---------V3
 * -          -
 * -          -
 * V1---------V4
 */

public class Rectangle : IGeometry
{
 
    private I2DVertex V1;
    private I2DVertex V2;
    private I2DVertex V3;
    private I2DVertex V4;
    
    public virtual double CalculateArea()
    {
        if (V4.X <= V1.X || V3.X <= V2.X) throw new WrongParamsException();
        if (V2.Y <= V1.Y || V3.Y <= V4.Y) throw new WrongParamsException();

        var V1_V4 = GetDistance(V1, V4);
        var V1_V2 = GetDistance(V1, V2);
        var V3_V4 = GetDistance(V3, V4);
        var V2_V3 = GetDistance(V2, V3);

        var TOLERANCE = 0.00001;
        if (Math.Abs(V1_V4 - V2_V3) > TOLERANCE) throw new WrongParamsException();
        if (Math.Abs(V1_V2 - V3_V4) > TOLERANCE) throw new WrongParamsException();

        return V1_V4 * V2_V3;
    }

    public Rectangle(I2DVertex V1, I2DVertex V2, I2DVertex V3, I2DVertex V4)
    {
        this.V1 = V1;
        this.V2 = V2;
        this.V3 = V3;
        this.V4 = V4;
    }
    

    public int VertexCount { get; } = 4;


    protected double GetDistance(I2DVertex V1, I2DVertex V2)
    {
        return Math.Sqrt((V1.X - V2.X) * (V1.X - V2.X) + (V1.Y - V2.Y) * (V1.Y - V2.Y));
    }
}