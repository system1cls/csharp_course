namespace App;

public static class Rectangles
{
    
    
    public static bool IsIntersected(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        
        if (IsPointInRecatangle(x1, x2, x3, y1, y2, y3, y4)) return true;
        
        if (IsPointInRecatangle(x1, x2, x4, y1, y2, y3, y4)) return true;
        
        if (IsPointInRecatangle(x3, x4, x1,  y3, y4, y1, y2 )) return true;
        
        if (IsPointInRecatangle(x3, x4, x2, y3, y4, y1, y2)) return true;
        
        return false;
    }

    private static bool IsPointInRecatangle(int x1, int x2, int x3, int y1, int y2, int y3, int y4)
    {
        return (x1 <= x3 && x3 <= x2 && ((y1 <= y3 && y3 <= y2) || (y1 <= y4 && y4 <= y2)));
    }
    
    public static bool IsNested(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {

        if (x3 <= x1 && x2 <= x4 && y3 <= y1 && y2 <= y4) return true;
        if (x1 <= x3 && x4 <= x2 && y1 <= y3 && y4 <= y2) return true;

        return false;
    }
}