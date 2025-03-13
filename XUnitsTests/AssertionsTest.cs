using XUnitsTests.Data;

namespace XUnitsTests;

public class AssertionsTest
{
    // 1. Assert.Equal() - Verifies that two values are equal.
    // 2. Assert.NotEqual() - Verifies that two values are not equal.
    // 3. Assert.True() - Verifies that the condition is true.
    // 4. Assert.False() - Verifies that the condition is false.
    // 5. Assert.Null() - Verifies that the value is null.
    // 6. Assert.NotNull() - Verifies that the value is not null.
    // 7. Assert.Empty() - Verifies that a collection is empty.
    // 8. Assert.NotEmpty() - Verifies that a collection is not empty.
    // 9. Assert.Same() - Verifies that two references refer to the same object.
    // 10. Assert.NotSame() - Verifies that two references do not refer to the same object.
    // 11. Assert.Contains() - Verifies that a collection contains a specific element.
    // 12. Assert.DoesNotContain() - Verifies that a collection does not contain a specific element. 
    // 13. Assert.InRange() - Verifies that a value is within a specified range.
    // 14. Assert.NotInRange() - Verifies that a value is not within a specified range.
    // 15. Assert.IsType() - Verifies that an object is of a specified type.
    // 16. Assert.IsNotType() - Verifies that an object is not of a specified type.


    [Fact]
    public void GetUser_ShouldReturnPassIfUserNameEqualBob()
    {
        // Arrange
        var user = new User()
        {
            Name = "Bob",
            Age = 20,
            IsAdmin = true,
        };
        var name = user.Name;

        // Assert
        Assert.Equal("Bob", name);
    }

    [Fact]
    public void GetUser_ShouldReturnPassIfUserNameIsNotEqualBob()
    {
        // Arrange
        var user = new User()
        {
            Name = "Saif",
            Age = 20,
            IsAdmin = true,
        };
        var name = user.Name;

        // Assert
        Assert.NotEqual("Bob", name);
    }

    [Fact]
    public void GetUser_ShouldReturnTrueIfUserIsAdmin()
    {
        // Arrange
        var user = new User()
        {
             Name = "bob",
             Age = 50
        };

        var isAdmin =  user.Age >= 35 ;
         
        // Assert
        Assert.True(isAdmin);
    }

    [Fact]
    public void GetUser_ShouldReturnFalseIfUserIsNotAdmin()
    {
        // Arrange
        var user = new User()
        {
            Name = "bob",
            Age = 15
        };
        var isAdmin = user.Age >= 35;

        // Assert
        Assert.False(isAdmin);
    }


    [Fact]
    public void GetUser_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var user = new User();

        // Act
        var result = user.GetUser();

        // Assert

        Assert.Null(result);  
    }

    [Fact]
    public void GetUser_ShouldReturnUser_WhenUserNameIsNotNullOrEmpty()
    {
        // Arrange
        var user = new User { Name = "bob" };

        // Act
        var result = user.GetUser();

        // Assert
        Assert.NotNull(result);  
        
    }

    [Fact]
    public void GetUser_ShouldReturnSameInstance()
    {
        // Arrange
        var bob = new User { Name = "bob" };
        var user = bob; // Point to the same object

        // Act & Assert
        Assert.Same(bob, user); 
    }

    [Fact]
    public void GetUser_ShouldReturnDifferentInstances()
    {
        // Arrange
        var user1 = new User { Name = "bob" };
        var user2 = new User { Name = "bob" };

        // Act & Assert
        Assert.NotSame(user1, user2);
    }

    [Fact]
    public void User_ShouldContainInList()
    {
        // Arrange
        var names = new List<string> { "bob", "adam", "ahmad" };
        var bob = new User { Name = "bob" };

        // Act & Assert
        Assert.Contains(bob.Name, names);
    }

    [Fact]
    public void User_ShouldNotContainInList()
    {
        // Arrange 
        var names = new List<string> {  "adam", "ahmad" };
        var bob = new User { Name = "bob" };
        // Act & Assert
        Assert.DoesNotContain(bob.Name, names); 

    }

    [Fact]
    public void UserAge_ShouldBeWithinRange()
    {
        // Arrange
        var user = new User()
        {
            Name = "bob",
            Age = 20
        };
        int age = user.Age;

        // Act & Assert
        Assert.InRange(age, 18, 100); // Assert that age is between 18 and 100
    }

    [Fact]
    public void UserAge_ShouldNotBeInRange()
    {
        // Arrange
        var user = new User()
        {
            Name = "bob",
            Age = 10
        };
        int age = user.Age;

        // Act & Assert
        Assert.NotInRange(age, 18, 100); // Assert that age is between 18 and 100
    }

    [Fact]
    public void GetUser_ShouldReturnUserType()
    {
        // Arrange
        var user = new User { Name = "bob" };

        // Act & Assert
        Assert.IsType<User>(user); 
    }

    [Fact]
    public void GetUser_ShouldNotReturnIncorrectType()
    {
        // Arrange
        var user = new User { Name = "bob" };

        // Act & Assert
        Assert.IsNotType<int>(user);  
    }

}
