using XUnitsTests.Data;

namespace XUnitsTests;

public class AssertionThrowsTest
{
    // 1. Assert.Throws() - Ensures an exception is thrown during the execution of a method.
    // 2. Assert.ThrowsAsync() - A version of Assert.Throws used for async methods. It is commonly used with methods that return Task or Task<T>.
    // 3. Assert.ThrowsAny() - Can be used when you want to verify that any exception is thrown.


    [Fact]
    public void ThrowArgumentException_ShouldThrowArgumentException()
    {
        // Arrange 
        var customException = new CustomException();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => customException.ThrowArgumentException());

        // Assert
        Assert.Equal(Messages.ArgumentExceptionMessage, exception.Message);
    }

    [Fact]
    public async Task DivideAsync_ShouldThrowDivideByZeroException_WhenDenominatorIsZero()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<DivideByZeroException>(() => DivideAsync(10, 0));

        // Assert
        Assert.Equal(Messages.DivideByZeroExceptionMessage, exception.Message);
    }


    [Fact]
    public void Random_ShouldThrowAnyException()
    {
        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() => ThrowRandomException());
        var type = exception is IndexOutOfRangeException || exception is NullReferenceException;
        
        // Assert
        Assert.True(type);
    }


    // Simulate async divide method
    public async Task<int> DivideAsync(int numerator, int denominator)
    {
        var customException = new CustomException();

        await Task.Delay(100);  
        if (denominator == 0)
            customException.ThrowDivideByZeroException();
     
        return numerator / denominator;
    }

    private void ThrowRandomException()
    {
        var rnd = Random.Shared.Next(0, 10);
        var customException = new CustomException();

        if (rnd > 5)
        {
            customException.ThrowIndexOutOfRangeException();
        }
        else
        {
            customException.ThrowNullReferenceException();
        }
    }

}
