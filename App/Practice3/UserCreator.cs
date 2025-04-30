namespace App.Practice3;

public static class UserCreator
{
    public static User createUser(string username, string password, string name, string surname, string inn, string phone)
    {
        User user = new User(Guid.NewGuid(), username, getHash(password), name, surname, inn, phone, DateTime.Now);
        return user;
    }   

    public static string getHash(string password)
    {
        System.Security.Cryptography.HMACMD5 hash = new System.Security.Cryptography.HMACMD5();
        hash.Initialize();
        hash.HashName = password;
        return hash.HashName;
    }
}