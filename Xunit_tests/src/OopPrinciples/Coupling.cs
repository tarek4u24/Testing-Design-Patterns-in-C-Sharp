using static BunsenBurner.ArrangeActAssert;
using ConsoleApp1.Coupling;
using FluentAssertions;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
namespace Xunit_tests;
public class Coupling
{
    private readonly ITestOutputHelper output;

    public Coupling(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async Task counpling_Test()
    {
        await Arrange(() =>
         {
             var emailSender = new EmailSender();
             var order = new Order(emailSender);
             var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
             return (order, consoleOutput);
         })
        .Act(async x =>
        {
            x.order.PlaceOrder();
            
            output.WriteLine("Order placed and notification sent.");
            output.WriteLine(x.consoleOutput.ToString());
            return x.consoleOutput.ToString();
        })
        .Assert(async result => {
            result.Should().NotBeNull();
            result.Should().Contain("Sending email: Order placed successfully");
            }
        );
    }// or assert on order state
}
