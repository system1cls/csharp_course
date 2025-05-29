using App.practice4;

namespace AppTests.practice4;

public class ServiceTests
{
    [Test]
    public void ServiceTest()
    {
        UsersService service = new UsersService();
        CreateUserDto user1Info = new CreateUserDto(
            "user1",
            "User123",
            "John",
            "Doe",
            "781633333333",
            "89230047406"
            );
        
        
        
        
        service.CreateUser(user1Info);
        
        Assert.True(service.LogIn("user1", user1Info.Password) != null);
        
        service.ChangePassword(service.LogIn("user1", user1Info.Password), user1Info.Password, "qwerty123456");
        
        Assert.Catch<Exception>(() => service.LogIn("user1", user1Info.Password));
        
        Assert.True(service.LogIn("user1", "qwerty123456") != null);
        
        
        service.DeleteUser(service.LogIn("user1", "qwerty123456"));
        
        Assert.Catch<Exception>(() => service.LogIn("user1", "qwerty123456"));
    }

    [Test]
    public void ServiceTest2()
    {
        UsersService service = new UsersService();
        CreateUserDto user1Info = new CreateUserDto(
            "user1",
            "User123",
            "John",
            "Doe",
            "781633333333",
            "89230047406"
        );
        
        CreateUserDto user2Info = new CreateUserDto(
            "user2",
            "Password",
            "John",
            "Doe",
            "781633333333",
            "89230047406"
        );
        
        CreateUserDto user3Info = new CreateUserDto(
            "user1",
            "User123",
            "John  123",
            "Do 123e",
            "781633333313 33",
            "89235547406"
        );
        
        
        Guid id1 = service.CreateUser(user1Info);
        Guid id2 = service.CreateUser(user2Info);
        
        Assert.True(service.LogIn("user1", user1Info.Password).Equals(id1));


        Assert.Catch<Exception>(() => service.CreateUser(user3Info));
    }
}