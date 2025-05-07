using App.practice2;

namespace AppTests.practice2;

public class INNTests
{

    [TestCase("000000000000", false)]
    [TestCase("0000000000", false)]
    [TestCase("504214222403", true)]
    [TestCase("775598987121", false)]
    [TestCase("263516479611", true)]
    public void Run(string inn, bool except)
    { 
        Assert.That(except.Equals(Inn.IsValidInn(inn)));
    }
}