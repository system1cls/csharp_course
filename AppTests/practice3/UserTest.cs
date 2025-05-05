using App.Practice3;

namespace AppTests.practice3;

public class UserTest
{   
    [Test]
    public void test1()
    {
        User user = UserCreator.createUser(
            "login",
            "password",
            "name",
            "surname",
            "793333333",
            "89230047406"
        );

        Assert.True(user.TryUpdatePhone("89235547406"));
        
        Assert.True(checkString(user.phone, "89235547406"));
        
        Assert.True(checkString(user.GetUserFullName(), "name surname"));

        Assert.True(checkString(user.passwordHash, UserCreator.getHash("password")));
    }


    private bool checkString(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i]) return false;
        }
        
        return true;
    }
    
}