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

        double V1_V4 = getDistance(V1, V4);
        double V1_V2 = getDistance(V1, V2);
        double V3_V4 = getDistance(V3, V4);
        double V2_V3 = getDistance(V2, V3);

        double diag1 = getDistance(V1, V3);
        
        var TOLERANCE = 0.00001;
        if (Math.Abs(V1_V4 - V2_V3) > TOLERANCE) throw new WrongParamsException("Sides are not equal");
        if (Math.Abs(V1_V2 - V3_V4) > TOLERANCE) throw new WrongParamsException("Sides are not equal");
        if (Math.Abs(diag1 - getPiphagorsValue(V1_V2, V1_V4)) > TOLERANCE) throw new WrongParamsException("It is`t a rectangle");

        return V1_V4 * V1_V2;
    }

    public Rectangle(I2DVertex V1, I2DVertex V2, I2DVertex V3, I2DVertex V4)
    {
        this.V1 = V1;
        this.V2 = V2;
        this.V3 = V3;
        this.V4 = V4;
    }
    

    public int VertexCount { get; } = 4;

    
    /*
     *  V2
     *  -
     *  -
     *  V1 -------V3
     */
    protected double getPiphagorsValue(double V1_V2, double V1_V3)
    {
        return Math.Sqrt(V1_V2 * V1_V2 + V1_V3 * V1_V3);
    }
    
    protected double getDistance(I2DVertex V1, I2DVertex V2)
    {
        return Math.Sqrt((V1.X - V2.X) * (V1.X - V2.X) + (V1.Y - V2.Y) * (V1.Y - V2.Y));
    }
}