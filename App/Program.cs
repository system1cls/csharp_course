using App.practice2;

namespace App;

public static class Program
{
    public static void Main()
    {
        string phone;
        Phone.TryParsePhone("8((923)004-74-06", out phone);
    }
}