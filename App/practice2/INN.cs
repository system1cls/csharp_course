namespace App.practice2;

public class INN
{  
    public static bool IsValidInn(string inn)
    {
        if (inn.Equals(new string('0', 10)) || inn.Equals(new string('0', 12))) return false;

        switch (inn.Length)
        {
            case 10:
                return isValidInnCompany(inn);
            case 12:
                return isValidInnIP(inn);
            default:
                return false;
        }
    }

    private static int CalcMul(string inn, int num, int[] coefs)
    {
        var sum = 0;
        for (var i = 0; i < num; i++)
        {
            sum += coefs[i] * (inn[i] - '0');
        }

        return sum;
    }
    
    private static bool isValidInnIP(string inn)
    {
        int[] coefs = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int[] coefs2 = {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };


        var sum1 = CalcMul(inn, 10, coefs);
        var sum2 = CalcMul(inn, 11, coefs2);

        return (sum1 % 11) % 10 == getIntFromDigit(inn[10])
               && (sum2 % 11) %
               10 == getIntFromDigit(inn[11]);

    }

    private static bool isValidInnCompany(string inn)
    {
        int[] coefs = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int sum = 0;

        sum = CalcMul(inn, 9, coefs);

        return (sum % 11) % 10 == getIntFromDigit(inn[9]);
    }


    private static int getIntFromDigit(char ch)
    {
        if (char.IsDigit(ch)) return ch - '0';
        else return -1;
    }
}