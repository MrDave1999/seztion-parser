namespace SeztionParser.Tests.Reader;

[TestClass]
public class SectionModelTests
{
    [TestMethod]
    public void Constructor_WhenNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var name = default(string);
        var data = new SectionData();

        // Act
        Action act = () => {
            var model = new SectionModel(name, data);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(name));
    }

    [TestMethod]
    public void Constructor_WhenDataIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var name = "Section";
        var data = default(ISectionData);

        // Act
        Action act = () => {
            var model = new SectionModel(name, data);
        };

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(data));
    }

    [TestMethod]
    [DynamicData(nameof(SectionContainsData), DynamicDataSourceType.Property)]
    public void ToString_WhenSectionContainsData_ShouldReturnsString(ISectionData data, string expectedString)
    {
        // Arrange
        var name = "Position";
        var model = new SectionModel(name, data);

        // Act
        var actual = model.ToString();

        // Assert
        actual.Should().Be(expectedString);
    }

    static IEnumerable<object[]> SectionContainsData
    {
        get
        {
            return
            [
                [
                    new SectionData { "1008", "1009" },
                    """
                    Section: Position ->
                    [
                       1008
                       1009
                    ]

                    """
                ],
                [
                    new SectionData { "1008" },
                    """
                    Section: Position -> [1008]

                    """
                ],
                [
                    new SectionData(),
                    """
                    Section: Position -> []

                    """
                ]
            ];
        }
    }
}
