using App.Practice3;

namespace App.practice4;

public class UsersService : IUsersService
{
    private List<User> _users = new List<User>();
    
    public User GetUser(Guid userId)
    {
        if (_users is null) throw new ArgumentNullException(nameof(_users));

        foreach (var user in _users)
        {
           if (user.Id.Equals(userId)) return user;
        }

        return null;
    }

    public Guid CreateUser(CreateUserDto createUserDto)
    {
        if (createUserDto is null) throw new ArgumentNullException(nameof(createUserDto));
        
        var newUser = UserCreator.CreateUser(
            createUserDto.Login,
            createUserDto.Password,
            createUserDto.Name,
            createUserDto.Surname,
            createUserDto.Inn,
            createUserDto.Phone
        );

        foreach (var user in _users)
        {
            if (user.Equals(newUser)) throw new Exception("This user is already exists");
        }
        
        _users.Add(newUser);
        return newUser.Id;
    }

    public void DeleteUser(Guid userId)
    {

        for (var i = 0; i < _users.Count; i++)
        {
            if (_users[i].Id.Equals(userId)) _users.RemoveAt(i);
            return;
        }
    }

    public void ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        foreach (var user in _users)
        {
            if (user.Id.Equals(userId))
            {
                if (user.PasswordHash.SequenceEqual(UserCreator.GetHash(oldPassword)))
                    user.PasswordHash = UserCreator.GetHash(newPassword);
                else throw new Exception("Passwords do not match");

                return;
            }
        }
    }

    public void UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        if (updateUserDto is null) throw new ArgumentNullException(nameof(updateUserDto));

        foreach (var user in _users)
        {
            if (user.Id.Equals(userId))
            {
                user.Name = updateUserDto.Name;
                user.Surname = updateUserDto.Surname;
                user.Inn = updateUserDto.Inn;
                user.Phone = updateUserDto.Phone;
                return;
            }
        }
    }

    public Guid LogIn(string login, string password)
    {
        foreach (var user in _users)
        {
            if (LoginCheck(user.Login, login) && HashCheck(user.PasswordHash, UserCreator.GetHash(password)))
            {
                return user.Id;
            } 
        }
        
        throw new Exception("Wrong Login or Password");
    }


    private bool LoginCheck(string login, string gettedLogin)
    {
        if (gettedLogin is null) throw new ArgumentNullException(nameof(gettedLogin));
        
        if (login.Length != gettedLogin.Length) return false;
        
        for (var i = 0; i < login.Length; i++) if (login[i] != gettedLogin[i]) return false;
        
        return true;
    }


    private bool HashCheck(string hash, string gettedHash)
    {
        if (hash.Length != gettedHash.Length) return false;
        
        for (var i = 0; i < hash.Length; i++) if (hash[i] != gettedHash[i]) return false;
        
        return true;
    }
}