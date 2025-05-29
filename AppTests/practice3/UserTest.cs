using App.Practice3;

namespace AppTests.practice3;

public class UserTest
{   
    [Test]
    public void Test1()
    {
        var user = new User();
        user.Phone = "89230047406";
        Assert.That(CheckStr(user.Phone, "89230047406"), Is.True);
        user.Phone = "59230047406";
        Assert.That(CheckStr(user.Phone, "89230047406"), Is.True);
    }


    private bool CheckStr(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;

        return !str1.Where((t, i) => t != str2[i]).Any();
    }
}