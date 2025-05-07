using App.practice2;

namespace AppTests.practice2;

public class MashineTest
{
    [TestCase( new string[]{
        "push Привет! Это снова я! Пока!",
        "pop 5",
        "push Как твои успехи? Плохо?","push qwertyuiop",
        "push 1234567890",
        "pop 27"
    }, "Привет! Это снова я! Как твои успехи?")]

    public void RunTest(string[] code, string res)
    {
        Assert.That(res.Equals(Mashine.CalculateString(code)));
        
    }
}