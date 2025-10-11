using ConsoleApp1.OopPrinciples.Abstraction;
namespace Xunit_tests;

public class AbstractionTests
{

    [Fact]
    public void EmailService_SendEmail_PrintsToConsole()
    {   // Arrange
        EmailService emailService = new EmailService();
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        emailService.sendEmail();

        // Assert
        string consoleOutput = output.ToString();
        Assert.Contains("Sending email", consoleOutput);
    }
}
