using ConsoleApp1.src.OopPrinciples.Composition;
using FluentAssertions;
namespace Xunit_tests;
public class CompositionTests
{
    [Fact]
    public void Car_StartCar_PrintsToConsole()
    {
        // Given
        Car car = new Car();
        // When
        car.StartCar();
        var output = new StringWriter();
        Console.SetOut(output);
        // Then
        car.Should().NotBeNull();
        output.ToString().Should().Contain("Engine started");
        output.ToString().Should().Contain("Wheels rotating");
        output.ToString().Should().Contain("Chassis supporting");
        output.ToString().Should().Contain("Sitting on seats");
        output.ToString().Should().Contain("Car started");
    }
}