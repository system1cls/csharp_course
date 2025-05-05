namespace App.practice4;




public class Triangle : IGeometry
{
    I2DVertex V1;
    I2DVertex V2;
    I2DVertex V3;

    public Triangle(I2DVertex V1, I2DVertex V2, I2DVertex V3)
    {
        this.V1 = V1;
        this.V2 = V2;
        this.V3 = V3;
    }
    
    public double CalculateArea()
    {
        return Math.Abs((V1.X * V2.Y + V2.X * V3.Y + V3.X * V1.Y - V1.Y * V2.X - V2.Y * V3.X - V3.Y * V1.X)/2);
    }

    public int VertexCount { get; } = 3;
}