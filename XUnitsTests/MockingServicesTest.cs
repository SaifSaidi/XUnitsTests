using Moq;
using XUnitsTests.Data;
using XUnitsTests.Services;

namespace XUnitsTests;

public class MockingServicesTest
{
    // Mocking List<User>
    private readonly Mock<List<User>> _userList = new Mock<List<User>>();

    // Mocking IConsoleLog Interface
    private readonly Mock<IConsoleLog> _log = new Mock<IConsoleLog>(); 

    private readonly IUserServices _userServices;


    public MockingServicesTest ()
    {
        // Object: return mock object
        _userServices = new UserServices(_userList.Object, _log.Object);

    }

    // Test for AddUser method: Add a valid user
    [Fact]
    public void AddUser_ShouldReturnTrue_WhenUserIsNotNull()
    {
        // Arrange

        var user = new User { Name = "Saif", Age = 25 };

        // Act
        var result = _userServices.AddUser(user);

        // Assert
        Assert.True(result);
        Assert.Contains(user, _userServices.GetAllUsers()); // Ensure the user is added to the list
    }

    // Test for AddUser method: Try to add a null user
    [Fact]
    public void AddUser_ShouldReturnFalse_WhenUserIsNull()
    { 

        // Act
        var result = _userServices.AddUser(null);

        // Assert
        Assert.False(result);
        Assert.Empty(_userServices.GetAllUsers()); // Ensure no user is added to the list
    }

    // Test for GetAllUsers method: Check if the list is empty
    [Fact]
    public void GetAllUsers_ShouldReturnEmptyList_WhenNoUsersAdded()
    {


        // Act
        var result = _userServices.GetAllUsers();

        // Assert
        Assert.Empty(result);
    }

    // Test for GetAllUsers method: Check if users are returned correctly
    [Fact]
    public void GetAllUsers_ShouldReturnListOfUsers_WhenUsersAdded()
    {


        var user1 = new User { Name = "Saif", Age = 25 };
        var user2 = new User { Name = "Ahmad", Age = 30 };
        _userServices.AddUser(user1);
        _userServices.AddUser(user2);

        // Act
        var result = _userServices.GetAllUsers();

        // Assert
        Assert.NotEmpty(result);
        Assert.Contains(user1, result);
        Assert.Contains(user2, result);
    }

    // Test for GetUserByName method: Retrieve an existing user by name
    [Fact]
    public void GetUserByName_ShouldReturnUser_WhenUserExists()
    {


        // Arrange
        var user = new User { Name = "Saif", Age = 25 };
        _userServices.AddUser(user);

        // Act
        var result = _userServices.GetUserByName("Saif");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Saif", result?.Name);
    }

    // Test for GetUserByName method: Try to retrieve a non-existent user
    [Fact]
    public void GetUserByName_ShouldReturnNull_WhenUserDoesNotExist()
    {


        // Act
        var result = _userServices.GetUserByName("NonExistentUser");

        // Assert
        Assert.Null(result);
    }

    // Test for RemoveUser method: Remove an existing user
    [Fact]
    public void RemoveUser_ShouldReturnTrue_WhenUserExists()
    {


        // Arrange
        var user = new User { Name = "Saif", Age = 25 };
        _userServices.AddUser(user);

        // Act
        var result = _userServices.RemoveUser("Saif");

        // Assert
        Assert.True(result);
        Assert.Empty(_userServices.GetAllUsers()); // Ensure the list is empty after removal
    }

    // Test for RemoveUser method: Try to remove a non-existent user
    [Fact]
    public void RemoveUser_ShouldReturnFalse_WhenUserDoesNotExist()
    {


        // Act
        var result = _userServices.RemoveUser("NonExistentUser");

        // Assert
        Assert.False(result);
    }
}

