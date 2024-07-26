namespace SeztionParser.Tests.Parser;

[TestClass]
public class ParserExceptionTests
{
    [TestMethod]
    public void Message_WhenActualValueIsDefined_ShouldReturnsFormattedMessage()
    {
        // Arrange
        var message = ExceptionMessages.SeccionIsRepeatedMessage;
        var actualValue = "Section";
        var exception = new ParserException(message, actualValue);
        var expectedMessage = $"{message} (Actual Value: Section)";

        // Act
        var actual = exception.Message;

        // Assert
        actual.Should().Be(expectedMessage);
    }

    [TestMethod]
    public void Message_WhenActualValueIsNotDefined_ShouldReturnsDefaultMessage()
    {
        // Arrange
        var exception = new ParserException();
        var expectedMessage = ExceptionMessages.ParserDefaultMessage;

        // Act
        var actual = exception.Message;

        // Assert
        actual.Should().Be(expectedMessage);
    }
}
