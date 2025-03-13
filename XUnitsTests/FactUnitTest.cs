
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XUnitsTests;

public class FactUnitTest
{
    // Fact: is a test that is always true, always produce the same result.
 
    [Fact]
    public void PassingTest_AddTwoNumber_ReturnPass()
    {
        var actual = Calc(5, 7);
        var expected = 12;

        // Assert 
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FailingTest_AddTwoNumber_ReturnFailed()
    {
        var actual = Calc(5, 7);
        var expected = 99;

        // Assert 
        Assert.NotEqual(expected, actual);

    }

    [Fact]
    public void PassingTest_AddMultipleNumbers_ReturnPass()
    {
        int[] numbers = [10, 2, 6, 7, 8, 5];
        var sum = 2;

        foreach (var number in numbers)
        {
            var actual = Calc(number, sum);
            var expected = number + sum;

            // Assert 
            Assert.Equal(expected, actual);

        }

    }
      
    private int Calc(int x, int y)
    {
        return x + y;
    }
}
