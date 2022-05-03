namespace SeztionParser.Tests;

[TestClass]
public class SectionDataConversionTests
{
    [TestMethod]
    public void ToDecimal_WhenTheConversionIsValid_ShouldReturnsAnEnumerable()
    {
        // Arrange
        string data = @"
                [section1]
                12.456
                13.564
                67.21
            ";
        var sections = new SectionsParser().Parse(data);
        var expected = new decimal[] { 12.456M, 13.564M, 67.21M };

        // Act
        var enumerable = sections.ToDecimal("section1");

        // Assert
        var actual = enumerable.ToArray();
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }

    [TestMethod]
    public void ToDouble_WhenTheConversionIsValid_ShouldReturnsAnEnumerable()
    {
        // Arrange
        string data = @"
                [section1]
                12.456
                13.564
                67.21
            ";
        var sections = new SectionsParser().Parse(data);
        var expected = new double[] { 12.456, 13.564, 67.21 };

        // Act
        var enumerable = sections.ToDouble("section1");

        // Assert
        var actual = enumerable.ToArray();
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }

    [TestMethod]
    public void ToFloat_WhenTheConversionIsValid_ShouldReturnsAnEnumerable()
    {
        // Arrange
        string data = @"
                [section1]
                12.456
                13.564
                67.21
            ";
        var sections = new SectionsParser().Parse(data);
        var expected = new float[] { 12.456f, 13.564f, 67.21f };

        // Act
        var enumerable = sections.ToFloat("section1");

        // Assert
        var actual = enumerable.ToArray();
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }

    [TestMethod]
    public void ToInt_WhenTheConversionIsValid_ShouldReturnsAnEnumerable()
    {
        // Arrange
        string data = @"
                [section1]
                12
                13
                67
            ";
        var sections = new SectionsParser().Parse(data);
        var expected = new int[] { 12, 13, 67 };

        // Act
        var enumerable = sections.ToInt("section1");

        // Assert
        var actual = enumerable.ToArray();
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }

    [TestMethod]
    public void ToLong_WhenTheConversionIsValid_ShouldReturnsAnEnumerable()
    {
        // Arrange
        string data = @"
                [section1]
                12
                13
                67
            ";
        var sections = new SectionsParser().Parse(data);
        var expected = new long[] { 12, 13, 67 };

        // Act
        var enumerable = sections.ToLong("section1");

        // Assert
        var actual = enumerable.ToArray();
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
        Assert.AreEqual(expected[2], actual[2]);
    }
}
