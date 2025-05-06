using System.Collections;

namespace App.practice4;

public class ClockwiseComparer : IComparer<I2DVertex>
{
    public int Compare(I2DVertex V1, I2DVertex V2)
    {
        if (ReferenceEquals(V1, V2)) return 0;
        if (V2 is null) return 1;
        if (V1 is null) return -1;
        
        var angle1 = Math.Atan2(V1.Y, V1.X);
        if (angle1 < 0) angle1 += 2 * Math.PI;
        
        var angle2 = Math.Atan2(V2.Y, V2.X);
        if (angle2 < 0) angle2 += 2 * Math.PI;
        
        
        
        return angle1.CompareTo(angle2);
    }
}