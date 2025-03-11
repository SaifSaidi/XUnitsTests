using XUnitsTests.Data;

namespace XUnitsTests;

public class NamingConventionsTest
{
    /*
     
    A common naming convention is to use the `Should` phrase. 
        This makes it clear what the method should do under certain conditions.

    Pattern:
       [ MethodName_StateUnderTest_ExpectedBehavior ]

   ** MethodName: The name of the method being tested.
   ** StateUnderTest: The conditions or input under which the method is being tested.
   ** ExpectedBehavior: The expected outcome or result.
    
     */


    [Fact]
    public void GetUserName_WhenUserNameIsNotNull_ReturnUserName()
    {
        // Arrange 
        var fakeUserName = "bob";
        var user = new User { Name = fakeUserName };
        // Act
        var userName = user.GetUserName();
        // Assert
        Assert.Equal(fakeUserName, userName);
    }

    [Fact]
    public void GetUserName_WhenUserNameIsNotWhiteSpace_ReturnUserName()
    {

        var fakeUserName = "bob";
        var user = new User { Name = fakeUserName };
        // Act
        var userName = user.GetUserName();
        // Assert
        Assert.Equal(fakeUserName, userName);
    }


    [Fact]
    public void GetUserName_WhenUserNameIsNull_ReturnEmptyMessage()
    {
        // Arrange 
        string? fakeUserName = null;
        var user = new User { Name = fakeUserName };

        // Act
        var userName = user.GetUserName();

        // Assert
        Assert.Equal(Messages.Empty, userName);

    }

    [Fact]
    public void GetUserName_WhenUserNameIsWhiteSpace_ReturnEmptyMessage()
    {
        // Arrange 
        string fakeUserName = " ";
        var user = new User { Name = fakeUserName };

        // Act
        var userName = user.GetUserName();

        // Assert
        Assert.Equal(Messages.Empty, userName);
    }

    [Fact]
    public void GetUser_WhenUserNameIsNotNull_ReturnUser()
    {
        // Arrange 
        string fakeUserName = "bob";
        var userObject = new User { Name = fakeUserName };

        // Act
        var user = userObject.GetUser();

        // Assert
        Assert.NotNull(user);
    }

    [Fact]
    public void GetUser_WhenUserNameIsNotWhiteSpace_ReturnUser()
    {
        // Arrange 
        string fakeUserName = "bob";
        var userObject = new User { Name = fakeUserName };

        // Act
        var user = userObject.GetUser();

        // Assert
        Assert.NotNull(user);
    }

    [Fact]
    public void GetUser_WhenUserNameIsNull_ReturnsNull()
    {
        // Arrange 
        string? fakeUserName = null;
        var userObject = new User { Name = fakeUserName };

        // Act
        var user = userObject.GetUser();

        // Assert
        Assert.Null(user);

    }

    [Fact]
    public void GetUser_WhenUserNameIsWhiteSpace_ReturnsNull()
    {
        // Arrange 
        string fakeUserName = " ";
        var userObject = new User { Name = fakeUserName };

        // Act
        var user = userObject.GetUser();

        // Assert
        Assert.Null(user);
    }

}
