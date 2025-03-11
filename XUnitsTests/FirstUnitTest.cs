
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XUnitsTests;

public class FirstUnitTest
{

    // names: XX-XX-XX
    // Fact: is a test that is always true, always produce the same result.
    // Theory: is a test that is parameterized, takes inputs and runs multiple times with different sets of data.
    
    [Fact]
    public void PassingTest_AddTwoNumber_ReturnPass()
    {
        var actual = Calc(5, 7); 
        var expected = 12; 

        // Assert
        // 12 == 12  true: pass
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FailingTest_AddTwoNumber_ReturnFailed() 
    {
        var actual = Calc(5, 7);
        var expected = 99; 

        // Assert
        // 12 == 99  false: failed
        Assert.Equal(expected, actual);

    }

    //[Fact]
    //public void PassingTest_AddMultipleNumbers_ReturnPass()
    //{
    //    int[] numbers = [10,2,6,7,8,5];
    //    var sum = 2;

    //    foreach (var number in numbers)
    //    {
    //        var actual = Calc(number, sum) ;
    //        var expected = number + sum;

    //        // Assert
    //        // 12 == 12  true: pass
    //        Assert.Equal(expected, actual);

    //    }

    //}

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(2, 2, 4)]
    [InlineData(2, 8, 10)]
    [InlineData(2, 9, 10)]
    [InlineData(100, -100, 0)]
    public void PassingTest_AddMultipleNumbers_ReturnPass(int xValue, int yValue, int expected)
    {

        var actual = Calc(xValue, yValue);
        Assert.Equal(expected, actual);

    }

    private int Calc(int x, int y)
    {
        return x + y;
    }
}