using XUnitsTests.Data;

namespace XUnitsTests;

public class AAAPatternTest
{
    // Arrange: Set up the necessary conditions for the test.
    /*
        Example:

        int x = 5;
        int y = 3; 
     */


    // Act:  Perform the action you are testing.
    /*
        Example:
        var actual = Calc(x, y);
     */


    // Assert: Verify the outcome.
    /*
        Example:
    
        Assert.Equal(expected, actual);

     */


    [Fact]
    public void Sum_TwoNumbers_ReturnsCorrectSum()
    {

        // Arrange
        int x = 5;
        int y = 7;
        var calc = new Calculator();
        // Act
        var actual = calc.Sum(x, y);
        
        // Assert 
        Assert.Equal(12, actual);
    }

    [Fact]
    public void Sum_TwoNumbers_ReturnsIncorrectSum_WhenExpectedSumIsDifferent()
    {
        // Arrange
        int x = 5;
        int y = 7;
        var calc = new Calculator();

        // Act
        var actual = calc.Sum(x, y); 

        // Assert

        Assert.Equal(99, actual);

    } 

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(2, 2, 4)]
    [InlineData(2, 8, 10)]
    [InlineData(2, 9, 10)]
    [InlineData(100, -100, 0)]
    public void Sum_VariousInputs_ReturnsCorrectSum(int xValue, int yValue, int expected)
    {

        // Arrange
        var calc = new Calculator();

        // Act
        var actual = calc.Sum(xValue, yValue);

        // Assert
        Assert.Equal(expected, actual);
    }

   
}
