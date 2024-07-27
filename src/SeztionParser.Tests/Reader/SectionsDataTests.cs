namespace SeztionParser.Tests.Reader;

[TestClass]
public class SectionsDataTests
{
    [TestMethod]
    public void Indexer_WhenSectionNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var sections = new SectionsData();
        var section = default(string);

        // Act
        Action act = () =>
        {
            ISectionData data = sections[section];
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(section));
    }

    [TestMethod]
    public void Indexer_WhenSectionNameIsNotFound_ShouldThrowSectionNotFoundException()
    {
        // Arrange
        var sections = new SectionsData();
        var sectionName = "Test";

        // Act
        Action act = () =>
        {
            ISectionData data = sections[sectionName];
        };

        // Assert
        act.Should().Throw<SectionNotFoundException>();
    }

    [TestMethod]
    public void Indexer_WhenSectionNameIsFound_ShouldReturnsSectionValues()
    {
        // Arrange
        var sections = new SectionsData
        {
            { 
                "Section", new SectionData { "Value1", "Value2" } 
            }
        };
        var sectionName = "Section";
        string[] expectedValues = ["Value1", "Value2"];

        // Act
        ISectionData data = sections[sectionName];

        // Assert
        data.Should().BeEquivalentTo(expectedValues);
    }

    [TestMethod]
    public void TryGetData_WhenSectionNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var sections = new SectionsData();
        var section = default(string);

        // Act
        Action action = () =>
        {
            bool value = sections.TryGetData(section, out _);
        };

        // Assert
        action.Should()
              .Throw<ArgumentNullException>()
              .WithParameterName(nameof(section));
    }

    [TestMethod]
    public void TryGetData_WhenSectionNameIsNotFound_ShouldReturnsFalse()
    {
        // Arrange
        var sections = new SectionsData();
        var sectionName = "Test";

        // Act
        bool actual = sections.TryGetData(sectionName, out _);

        // Assert
        actual.Should().BeFalse();
    }

    [TestMethod]
    public void TryGetData_WhenSectionNameIsFound_ShouldReturnsTrue()
    {
        // Arrange
        var sections = new SectionsData
        {
            {
                "Section", new SectionData { "Value1", "Value2" }
            }
        };
        var sectionName = "Section";
        string[] expectedValues = ["Value1", "Value2"];

        // Act
        bool actual = sections.TryGetData(sectionName, out ISectionData data);

        // Asserts
        actual.Should().BeTrue();
        data.Should().BeEquivalentTo(expectedValues);
    }

    [TestMethod]
    public void ToString_WhenConvertingSectionsDataToString_ShouldReturnsString()
    {
        // Arrange
        var sections = new SectionsData
        {
            {
                "Example1", new SectionData { "Value1", "Value2" }
            },
            {
                "Example2", new SectionData { "Value1", "Value2" }
            }
        };
        var expectedString =
        """
        Section: Example1 ->
        [
           Value1
           Value2
        ]
        Section: Example2 ->
        [
           Value1
           Value2
        ]

        """;

        // Act
        var actual = sections.ToString();

        // Assert
        actual.Should().Be(expectedString);
    }
}
