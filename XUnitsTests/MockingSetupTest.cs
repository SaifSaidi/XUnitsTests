using Moq;
using Xunit.Abstractions;
using XUnitsTests.Data;

namespace XUnitsTests;

public class MockingSetupTest
{
    /*
         Note: `ITestOutputHelper` It captures the output during the test run and displays it in the test result log (console, Visual Studio, etc.)

        1. the `Object`: This property gives you access to the actual mock object, which implements the interface or class you are mocking.

        2. the `Name`: property in Moq is an optional feature that helps you assign a readable name to a mock object.
            useful for debugging and logging to make your tests clearer

        3. The `Setup`: method is used to define the behavior of a mock method or property. It specifies what should happen when a specific method or property is called on the mock object.

        4. `Verifiable`, `Verify`:  check whether a particular method or property on the mock object was called during the test.

        5. The `Callback` method allows you to specify a custom action to execute when a method on the mock is called. 
    
     */

    readonly ITestOutputHelper _outputHelper;

    public MockingSetupTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturnCorrectSum()

    {
        // Arrange
        //var calculator = new AddCalculator();
        var mockCalculator = new Mock<ICalculator>();

        mockCalculator.Name = "Add Two Numbers";

        // add -5 + 4 is -1: always

        mockCalculator
           .Setup(setup => setup.Calc(-5, 4)) // Adding
           .Returns(-1);
       
        //var calc = new CalculatorServices(calculator);
        var mockCalcService = new CalculatorServices(mockCalculator.Object);

        // Act
        //var actual = calc.Execute(-5, 4);
        var actual = mockCalcService.Execute(-5, 4); // sholud return -1

        // Assert
        Assert.Equal(-1, actual);
    }


    [Fact]
    public void MultiplicationTwoNumbers_ShouldReturnCorrectMultiplication()

    {

        // Arrange
        //var calculator = new MultiplicationCalculator();
        var mockCalculator = new Mock<ICalculator>();

        mockCalculator.Name = "Multiplication Two Numbers";

        // mult 5 * 5 is 25: always

        mockCalculator
          .Setup(setup => setup.Calc(5, 5)) // Multiplication
          .Returns(25);

        //var calc = new CalculatorServices(calculator);
        var mockCalcService = new CalculatorServices(mockCalculator.Object);

        // Act
        //var actual = calc.Execute(5, 5);
        var actual = mockCalcService.Execute(5, 5); // should return 25

        // Assert
        Assert.Equal(25, actual);
    }


    [Fact]
    public void AddTwoNumbers_ShouldReturnCorrectSumWithVerifiable()

    {
        // Arrange
        //var calculator = new AddCalculator();
        var mockCalculator = new Mock<ICalculator>();

        mockCalculator.Name = "Add Two Numbers";

        mockCalculator
            .Setup(setup => setup.Calc(5, 5)) // Adding
            .Returns(10)
            .Verifiable();

        mockCalculator
           .Setup(setup => setup.Calc(-5, 4)) // Adding
           .Returns(-1)
           .Verifiable();

        mockCalculator
         .Setup(setup => setup.Calc(5, 5)) // Adding
         .Returns(10)
         .Verifiable();


        //var calc = new CalculatorServices(calculator);
        var mockCalcService = new CalculatorServices(mockCalculator.Object);

        // Act
        //var actual = calc.Execute(5, 4);
        var actualVerify1 = mockCalcService.Execute(5, 5);
        var actualVerify2 = mockCalcService.Execute(-5, 4);
        var actualVerify3 = mockCalcService.Execute(5, 5);  
        // Assert
        Assert.Equal(10, actualVerify1);
        Assert.Equal(-1, actualVerify2);
        Assert.Equal(10, actualVerify3);

        mockCalculator.Verify();
        //mockCalculator.Verify(a => a.Calc(5, 5), Times.Once); // error:2 time mockCalcService.Execute(5, 5);  
        //mockCalculator.Verify(a => a.Calc(It.IsAny<int>() , It.IsAny<int>()), Times.Once); // error: 3 times: a => a.Calc(It.IsAny<int>(), It.IsAny<int>())

    }


    [Fact]
    public void MultiplicationTwoNumbers_ShouldReturnCorrectMultiplicationWithCallbacks()

    {

        // Arrange
        //var calculator = new MultiplicationCalculator();
        var mockCalculator = new Mock<ICalculator>();

        mockCalculator.Name = "Multiplication Two Numbers";

        mockCalculator
          .Setup(setup => setup.Calc(5, 5)) // Multiplication
          .Returns(25)
          .Callback<int, int>((x, y) => _outputHelper.WriteLine($"Multiplication 5 * 5 = 25"));

        mockCalculator
        .Setup(setup => setup.Calc(3, 5)) // Multiplication
        .Returns(15)
        .Callback<int, int>((x, y) => _outputHelper.WriteLine($"Multiplication 3 * 5 = 15"));

        //var calc = new CalculatorServices(calculator);
        var mockCalcService = new CalculatorServices(mockCalculator.Object);

        // Act
        //var actual = calc.Execute(5, 4);
        var actual = mockCalcService.Execute(5, 5); // should return 25
        var actual2 = mockCalcService.Execute(3, 5); // should return 25

        // Assert
        Assert.Equal(25, actual);
        Assert.Equal(15, actual2);
    }


    [Fact]
    public void CalcExecuteMethod_ShouldReturnCorrect()

    {

        // Arrange
        ICalculator calculator = new AddCalculator();
        //ICalculator calculator = new MultiplicationCalculator();

        switch (calculator)
        {
            case AddCalculator add:
                {
                    var mockCalcService = new CalculatorServices(add);

                    // Act
                    var actual = mockCalcService.Execute(5, 5); // should return 10

                    // Assert
                    Assert.Equal(10, actual);
                }

                break;

            case MultiplicationCalculator multiplication:
                {
                    var mockCalcService = new CalculatorServices(multiplication);

                    // Act
                    var actual = mockCalcService.Execute(5, 5); // should return 25

                    // Assert
                    Assert.Equal(25, actual);
                }

                break;
        }


    }
}


public class CalculatorServices
{
    private readonly ICalculator _calculator;

    public CalculatorServices(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public int Execute(int x, int y)
    {
        return _calculator.Calc(x, y);
    }
}