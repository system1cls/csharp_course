using App.Practice3;

namespace AppTests.practice3;

public class UserTest
{   
    [Test]
    public void Test1()
    {
        User user1 = new User(Guid.Empty, "systemCLS", "111HAHA", "Dmitrii", "Faranosov", 
            "12312322", "+7(923)004-74-06", new DateTime(2001, 1, 1));
        User user2 = new User(Guid.Empty, "abc", "abcd", "abc", "d", "1", "8-456-254-2525",
            new DateTime(2000, 1, 1));

        Assert.That(user1.GetUserFullName().Equals("Dmitrii Faranosov"));
        Assert.That(user2.TryUpdatePhone("+7-923-004-74-06"));
    }
    
}