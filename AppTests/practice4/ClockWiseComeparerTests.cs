using System.Collections;
using App.practice4;

namespace AppTests.practice4;

public class ClockWiseComeparerTests
{
    [Test]
    public void ClockWiseComeparerTest()
    {
        I2DVertex[]vertexes = new I2DVertex[4];

        vertexes[0] = new MyVertex(-5, 1);
        vertexes[1] = new MyVertex(1, 1);
        vertexes[2] = new MyVertex(2, -2);
        vertexes[3] = new MyVertex(-3, -3);
        
        Array.Sort(vertexes, new ClockwiseComparer());
        
        Assert.True(vertexes[0].X == 1 && vertexes[0].Y == 1);
        Assert.True(vertexes[1].X == -5 && vertexes[1].Y == 1);
        Assert.True(vertexes[2].X == -3 && vertexes[2].Y == -3);
        Assert.True(vertexes[3].X == 2 && vertexes[3].Y == -2);
        
        
    }
}