namespace App.practice4;

public class Logger
{
    public string LogGeometry(IGeometry geometry)
    {
        if (geometry is Square) return "Квадрат";
        if (geometry is Rectangle) return "Прямоугольник";
        if (geometry is Triangle) return "Треугольник";
        return "неизвестная геометрия";
    }
}