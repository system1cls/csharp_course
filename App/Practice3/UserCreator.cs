using System.Text;

namespace App.Practice3;

public static class UserCreator
{
    public static User CreateUser(string username, string password, string name, string surname, string inn, string phone)
    {
        User user = new User(Guid.NewGuid(), username, GetHash(password), name, surname, inn, phone, DateTime.Now);
        return user;
    }   

    public static string GetHash(string password)
    {
        
        using (var hasher = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(password)))
        {
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}