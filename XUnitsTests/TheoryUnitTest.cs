namespace XUnitsTests;
public class TheoryUnitTest
{ 
     // Theory: is a test that is parameterized, takes inputs and runs multiple times with different sets of data.
     
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
    [InlineData(100, -100, 0)]
    public void PassingTest_AddMultipleNumbers_ReturnEqual(int xValue, int yValue, int expected)
    {

        var actual = Calc(xValue, yValue);
        Assert.Equal(expected, actual);

    }

    [Theory]
    [InlineData(0, 0, -1)]
    [InlineData(2, 2, 5)]
    [InlineData(2, 8, 18)]
    [InlineData(100, -100, 1)]
    public void PassingTest_AddMultipleNumbers_ReturnNotEqual(int xValue, int yValue, int expected)
    {

        var actual = Calc(xValue, yValue);
        Assert.NotEqual(expected, actual);

    }
    private int Calc(int x, int y)
    {
        return x + y;
    }
}