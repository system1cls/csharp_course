namespace App.practice4;




public class Triangle : IGeometry
{
    I2DVertex V1;
    I2DVertex V2;
    I2DVertex V3;

    Triangle(I2DVertex v1, I2DVertex v2, I2DVertex v3)
    {
        this.V1 = V1;
        this.V2 = V2;
        this.V3 = V3;
    }
    
    public double CalculateArea()
    {
        return (V1.X * (V2.Y - V3.Y) + V2.X * (V3.Y - V1.Y) + V3.X * (V1.Y - V2.Y));
    }

    public int VertexCount { get; } = 3;
}