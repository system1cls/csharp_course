using App;

namespace AppTests;

public class PaymentsTests
{
    
    [TestCase(PaymentsPlan.Annuity, 7, 3, 10000, 10116.90)]
    [TestCase(PaymentsPlan.Differentiated, 3, 5, 200000, 201500)]
    [TestCase(PaymentsPlan.Differentiated, 4, 15, 100000, 102666.70)]
    [TestCase(PaymentsPlan.Annuity, 4, 15, 100000, 102687.40)]
    [TestCase(PaymentsPlan.Annuity, 10, 10, 20000, 20928.10)]
    [TestCase(PaymentsPlan.Differentiated, 10, 10, 20000, 20916.70)]
    [TestCase(PaymentsPlan.Differentiated, 15, 12, 3000000, 3243750.00)]
    [TestCase(PaymentsPlan.Annuity, 15, 12, 3000000, 3249299.20)]
    public void TestPasses_When_Result_Correct(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount, decimal expected)
    {
        var actual = Payments.CalculateTotalPayments(plan, rate, monthsCount, amount);
        Assert.That(actual, Is.EqualTo(expected));
    }
}