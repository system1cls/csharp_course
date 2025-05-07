namespace App;

public static class Rectangles
{
    
    
    public static bool IsIntersected(
        // первый прямоугольник
        int x1, int y1, int x2, int y2,
        // второй прямоугольник
        int x3, int y3, int x4, int y4)
    {
        if (x1 <= x3 && x3 <= x2 && ((y1 <= y3 && y3 <= y2) || (y1 <= y4 && y4 <= y2))) return true;
        if (x1 <= x4 && x4 <= x2 && ((y1 <= y3 && y3 <= y2) || (y1 <= y4 && y4 <= y2))) return true;
        if (x3 <= x1 && x1 <= x4 && ((y3 <= y1 && y1 <= y4) || (y3 <= y2 && y2 <= y4))) return true;
        if (x3 <= x2 && x2 <= x4 && ((y3 <= y1 && y1 <= y4) || (y3 <= y2 && y2 <= y4))) return true;
        
        return false;
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