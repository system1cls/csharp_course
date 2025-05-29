using App.Practice3;

namespace App.practice4;

public interface IUsersService
{
    User GetUser(Guid userId);
    Guid CreateUser(CreateUserDto createUserDto);
    void DeleteUser(Guid userId);
    void ChangePassword(Guid userId, string oldPassword, string newPassword);
    void UpdateUser(Guid userId, UpdateUserDto updateUserDto);

    Guid LogIn(string login, string password);
}