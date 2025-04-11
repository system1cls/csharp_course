namespace App.practice2;

public class INN
{  
    public static bool IsValidInn(string inn)
    {
        if (inn.Length != 10 && inn.Length != 12) return false;
        if (inn.Equals("0000000000") || inn.Equals("000000000000")) return false;

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

    private static int calcMul(string inn, int num, int[] coefs)
    {
        int sum = 0;
        for (int i = 0; i < num; i++)
        {
            sum += coefs[i] * (inn[i] - '0');
        }

        return sum;
    }
    
    private static bool isValidInnIP(string inn)
    {
        int[] coefs = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int[] coefs2 = {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int sum1 = 0, sum2 = 0;

        sum1 = calcMul(inn, 10, coefs);
        sum2 = calcMul(inn, 11, coefs2);

        return (sum1 % 11) % 10 == (int)(inn[10] - '0')
               && (sum2 % 11) %
               10 == (int)(inn[11] - '0');

    }

    private static bool isValidInnCompany(string inn)
    {
        int[] coefs = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
        int sum = 0;

        sum = calcMul(inn, 9, coefs);

        return (sum % 11) % 10 == (int)(inn[9] - '0');
    }
}