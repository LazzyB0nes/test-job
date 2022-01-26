using GeometryCalculator;
using Xunit;

namespace Tests;

public class GeometryCalculator_Tests
{
    [Theory]
    [InlineData(2)]
    public void CircleInstane_Test(int value)
    {
        Circle circle = new(value);
        double squareResult = circle.Square();

        Assert.Equal(12.57, squareResult, 2);
    }
    [Theory]
    [InlineData(2)]
    public void GeometryCalculatorCircleSquare_Test(int radius)
    {
        Assert.Equal(12.57, GeometryCalculator.Calculator.Square(radius), 2);
    }
    
    [Theory]
    [InlineData(3, 4, 5)]
    public void GeometryCalculatorTriangleSquare_Test(int sideA, int sideB, int sideC)
    {
        Assert.Equal(6.0, GeometryCalculator.Calculator.Square(sideA, sideB, sideC), 2);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    public void TriangleInstane_Test(int sideA, int sideB, int sideC)
    {
        Triangle triangle = new(sideA, sideB, sideC);
        double squareResult = triangle.Square();

        Assert.Equal(6.0, squareResult, 2);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    public void IsTriangleRightAngled_Test(int sideA, int sideB, int sideC)
    {
        Triangle triangle = new(sideA, sideB, sideC);

        Assert.True(triangle.IsRightAngled);
    }

    [Theory]
    [InlineData(4, 4, 5)]
    public void IsTriangleNotRightAngled_Test(int sideA, int sideB, int sideC)
    {
        Triangle triangle = new(sideA, sideB, sideC);

        Assert.False(triangle.IsRightAngled);
    }
}