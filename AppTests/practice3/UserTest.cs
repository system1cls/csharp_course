using App.Practice3;

namespace AppTests.practice3;

public class UserTest
{   
    [Test]
    public void test1()
    {
        User user = new User();
        user.phone = "89230047406";
        Assert.True(checkStr(user.phone, "89230047406"));
        user.phone = "59230047406";
        Assert.True(checkStr(user.phone, ""));
    }


    private bool checkStr(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;
        
        for (int i = 0; i < str1.Length; i++) if (str1[i] != str2[i]) return false;
        
        return true;
    }
}