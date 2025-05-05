using App.Practice3;

namespace App.practice4;

public class UsersService : IUsersService
{
    List<User> users = new List<User>();
    
    public User GetUser(Guid userId)
    {
        if (users is null) throw new ArgumentNullException(nameof(users));

        foreach (var user in users)
        {
           if (user.id.Equals(userId)) return user;
        }

        return null;
    }

    public Guid CreateUser(CreateUserDto createUserDto)
    {
        if (createUserDto is null) throw new ArgumentNullException(nameof(createUserDto));
        
        User newUser = UserCreator.createUser(
            createUserDto.Login,
            createUserDto.Password,
            createUserDto.Name,
            createUserDto.Surname,
            createUserDto.Inn,
            createUserDto.Phone
        );

        foreach (var user in users)
        {
            if (user.Equals(newUser)) throw new Exception("This user is already exists");
        }
        
        users.Add(newUser);
        return newUser.id;
    }

    public void DeleteUser(Guid userId)
    {

        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].id.Equals(userId)) users.RemoveAt(i);
            return;
        }
    }

    public void ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        foreach (var user in users)
        {
            if (user.id.Equals(userId))
            {
                if (user.passwordHash.SequenceEqual(UserCreator.getHash(oldPassword)))
                    user.passwordHash = UserCreator.getHash(newPassword);
                else throw new Exception("Passwords do not match");

                return;
            }
        }
    }

    public void UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        if (updateUserDto is null) throw new ArgumentNullException(nameof(updateUserDto));

        foreach (var user in users)
        {
            if (user.id.Equals(userId))
            {
                user.name = updateUserDto.Name;
                user.surname = updateUserDto.Surname;
                user.inn = updateUserDto.Inn;
                user.phone = updateUserDto.Phone;
                return;
            }
        }
    }

    public Guid LogIn(string login, string password)
    {
        foreach (var user in users)
        {
            if (loginCheck(user.login, login) && hashCheck(user.passwordHash, UserCreator.getHash(password)))
            {
                return user.id;
            } 
        }
        
        throw new Exception("Wrong Login or Password");
    }


    private bool loginCheck(string login, string gettedLogin)
    {
        if (gettedLogin is null) throw new ArgumentNullException(nameof(gettedLogin));
        
        if (login.Length != gettedLogin.Length) return false;
        
        for (int i = 0; i < login.Length; i++) if (login[i] != gettedLogin[i]) return false;
        
        return true;
    }


    private bool hashCheck(string hash, string gettedHash)
    {
        if (hash.Length != gettedHash.Length) return false;
        
        for (int i = 0; i < hash.Length; i++) if (hash[i] != gettedHash[i]) return false;
        
        return true;
    }
}