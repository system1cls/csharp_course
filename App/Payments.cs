namespace App;

public enum PaymentsPlan
{
    Differentiated,
    Annuity
}

public class Payments
{
    public static decimal CalculateTotalPayments(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount)
    {
        var drate= rate / 12 / 100;
        switch (plan)
        {
            case PaymentsPlan.Differentiated:
                return Decimal.Round(amount * (1 + drate * (monthsCount + 1) / 2), 1);
            case PaymentsPlan.Annuity:
                // (1 + rate/100)^cntMonth
                decimal koef = (decimal)Math.Pow((double)(1 + drate), monthsCount);
                return Decimal.Round(monthsCount * amount * (drate +  drate/ (koef - 1)), 1);
            default:
                Console.WriteLine("Unknown plan");
                return 0;
        }
    }
}