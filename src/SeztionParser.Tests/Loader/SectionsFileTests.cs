namespace SeztionParser.Tests.Loader;

[TestClass]
public class SectionsFileTests
{
    [TestMethod]
    public void Load_WhenSectionValueIsRead_ShouldReturnsSectionValues()
    {
        // Arrange
        var path = Path.Combine("Loader", "sample.ini");
        string[] expectedValues = ["Value1", "Value2"];

        // Act
        var sections = SectionsFile.Load(path);

        // Asserts
        sections["Section1"].Should().BeEquivalentTo(expectedValues);
        sections["Section2"].Should().BeEquivalentTo(expectedValues);
    }

    [TestMethod]
    public void Load_WhenFileIsNotFound_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var path = Path.Combine("Loader", "not_found.ini");

        // Act
        Action act = () => SectionsFile.Load(path);

        // Assert
        act.Should().Throw<FileNotFoundException>();
    }
}
