namespace SeztionParser.Tests;

[TestClass]
public class SingleLineSectionTests
{
    [TestMethod]
    public void GetFirstLineDecimal_WhenTheConversionIsValid_ShouldReturnDecimal()
    {
        // Arrange
        string data = @"
            [section1]
            12.456
        ";
        var sections = new SectionsParser().Parse(data);
        decimal expected = 12.456M;

        // Act
        decimal actual = sections.GetFirstLineDecimal("section1");

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetFirstLineDouble_WhenTheConversionIsValid_ShouldReturnDouble()
    {
        // Arrange
        string data = @"
            [section1]
            12.456
        ";
        var sections = new SectionsParser().Parse(data);
        double expected = 12.456;

        // Act
        double actual = sections.GetFirstLineDouble("section1");

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetFirstLineFloat_WhenTheConversionIsValid_ShouldReturnFloat()
    {
        // Arrange
        string data = @"
            [section1]
            12.456
        ";
        var sections = new SectionsParser().Parse(data);
        float expected = 12.456f;

        // Act
        float actual = sections.GetFirstLineFloat("section1");

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetFirstLineInt_WhenTheConversionIsValid_ShouldReturnInt()
    {
        // Arrange
        string data = @"
            [section1]
            12
        ";
        var sections = new SectionsParser().Parse(data);
        int expected = 12;

        // Act
        int actual = sections.GetFirstLineInt("section1");

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void GetFirstLineLong_WhenTheConversionIsValid_ShouldReturnLong()
    {
        // Arrange
        string data = @"
            [section1]
            12
        ";
        var sections = new SectionsParser().Parse(data);
        long expected = 12;

        // Act
        long actual = sections.GetFirstLineLong("section1");

        // Assert
        actual.Should().Be(expected);
    }
}
