namespace App;

using App.Practice3;
public static class Program
{
    public static void Main()
    {
        User user1 = new User(new Guid("1"), "systemCLS", "111HAHA", "Dmitrii", "Faranosov", 
            "12312322", "+7(923)004-74-06", new DateTime(2001, 1, 1));
        User user2 = new User(new Guid("2"), "abc", "abcd", "abc", "d", "1", "8-456-254-2525",
            new DateTime(2000, 0, 0));

        user1.GetUserFullName();
        

    }
}