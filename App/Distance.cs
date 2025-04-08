namespace App;

public static class Distance
{
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2) 
    {
        
        if (x1 == x2 && y1 == y2) return Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y1 - y1));
        
        double myx1, myx2, myy1, myy2;

        if (x2 < x1)
        {
            myx1 = x2;
            myx2 = x1;
            myy1 = y2;
            myy2 = y1;
        }
        else
        {
            myx1 = x1;
            myx2 = x2;
            myy1 = y1;
            myy2 = y2;
        }

        // f(x) = ax + b
        // p(AB, d) = |ax - y + b| / sqrt(a*a + 1)
        
        double a, b;

        double TOLERANCE = 0.000001;
        if (Math.Abs(x1 - x2) < TOLERANCE)
        {
            double temp1 = myy1;
            double temp2 = myy2;
            myy1 = myx1;
            myy2 = myx2;
            myx1 = temp1;
            myx2 = temp2;
            (y, x) = (x, y);
        }
        a = (myy2 - myy1) / (myx2 - myx1); 
        b = myy2 - a * myx2;

        var dist = Math.Abs(a * x - y + b) / Math.Sqrt(a * a + 1);
        // координата точки соприкосновения
        double xs;
        
        if (a != 0)
        {
            // Расстояние от данной точки до точки соприкосновения по х 
            var xd = dist / Math.Sqrt(1 + 1 / a * a);

            


            if (a * x + b > y) xs = x - xd * Math.Sign(a);
            else xs = x + xd * Math.Sign(a);
            
        }
        else
        {
            xs = x;
        }

        if (myx1 <= xs && xs <= myx2) return dist;
        if (xs <= myx1) return Math.Sqrt((x - myx1) * (x - myx1) + (y - myy1) * (y - myy1));
        else return Math.Sqrt((x - myx2) * (x - myx2) + (y - myy2) * (y - myy2));
        
    }
}