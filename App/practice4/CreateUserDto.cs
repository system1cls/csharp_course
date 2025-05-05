namespace App.practice4;

public sealed class CreateUserDto
{
    public string Login { get; init; }
    public string Password { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Inn { get; init; }
    public string Phone { get; init; }

    public CreateUserDto(string login, string password, string name, string surname, string inn, string phone)
    {
        Login = login;
        Password = password;
        Name = name;
        Surname = surname;
        Inn = inn;
        Phone = phone;
    }
    
}
