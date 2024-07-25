namespace SeztionParser.Tests.Reader;

[TestClass]
public class SectionDataConversionTests
{
    [TestMethod]
    public void ToDecimal_WhenConversionIsValid_ShouldReturnsEnumerable()
    {
        // Arrange
        var data = @"
            [section1]
            12.456
            13.564
            67.21
        ";
        var sections = new SectionsParser().Parse(data);
        decimal[] expected = [12.456M, 13.564M, 67.21M];

        // Act
        var enumerable = sections.ToDecimal("section1");
        var actual = enumerable.ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ToDouble_WhenConversionIsValid_ShouldReturnsEnumerable()
    {
        // Arrange
        var data = @"
            [section1]
            12.456
            13.564
            67.21
        ";
        var sections = new SectionsParser().Parse(data);
        double[] expected = [12.456, 13.564, 67.21];

        // Act
        var enumerable = sections.ToDouble("section1");
        var actual = enumerable.ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ToFloat_WhenConversionIsValid_ShouldReturnsEnumerable()
    {
        // Arrange
        var data = @"
            [section1]
            12.456
            13.564
            67.21
        ";
        var sections = new SectionsParser().Parse(data);
        float[] expected = [12.456f, 13.564f, 67.21f];

        // Act
        var enumerable = sections.ToFloat("section1");
        var actual = enumerable.ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ToInt_WhenConversionIsValid_ShouldReturnsEnumerable()
    {
        // Arrange
        var data = @"
            [section1]
            12
            13
            67
        ";
        var sections = new SectionsParser().Parse(data);
        int[] expected = [12, 13, 67];

        // Act
        var enumerable = sections.ToInt("section1");
        var actual = enumerable.ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ToLong_WhenConversionIsValid_ShouldReturnsEnumerable()
    {
        // Arrange
        var data = @"
            [section1]
            12
            13
            67
        ";
        var sections = new SectionsParser().Parse(data);
        long[] expected = [12, 13, 67];

        // Act
        var enumerable = sections.ToLong("section1");
        var actual = enumerable.ToArray();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
