namespace SeztionParser.Tests.Parser;

[TestClass]
public class SectionsParserTests
{
    [TestMethod]
    public void Parse_WhenSectionNameIsCaseInsensitive_ShouldReturnsSectionValues()
    {
        // Arrange
        var data = @"
            [Section]   
            A
            B
        ";
        var parser = new SectionsParser();
        string[] expectedValues = ["A", "B"];

        // Act
        var sections = parser.Parse(data);

        // Asserts
        sections["Section"].Should().BeEquivalentTo(expectedValues);
        sections["section"].Should().BeEquivalentTo(expectedValues);
        sections["SECTION"].Should().BeEquivalentTo(expectedValues);
    }

    [TestMethod]
    public void Parse_WhenSectionNameIsRead_ShouldReturnsSections()
    {
        // Arrange
        var data = @"
            [section1]   
            23
            15
            [section2]
            32
            11
            [section3]
            3
        ";
        var parser = new SectionsParser();
        string[] expectedSections = ["section1", "section2", "section3"];

        // Act
        var sections = parser.Parse(data);
        var sectionNames = sections.GetNames();

        // Assert
        sectionNames.Should().BeEquivalentTo(expectedSections);
    }

    [TestMethod]
    public void Parse_WhenSectionValueIsRead_ShouldReturnsSectionValues()
    {
        var data = @"
            [section1]   
            1
            2
            3
            4
            [section2]
            1
            2
            3
            4
        ";
        var parser = new SectionsParser();
        string[] expectedValues = ["1", "2", "3", "4"];

        // Act
        var sections = parser.Parse(data);

        // Assert
        sections["section1"].Should().Contain(expectedValues);
        sections["section2"].Should().Contain(expectedValues);
    }

    [TestMethod]
    public void Parse_WhenCommentIsRead_ShouldIgnoreComments()
    {
        // Arrange
        var data = @"
            #comment1
            [section1]
            #comment2
            23
            #comment3       
            15
            #comment4
            [section2]
            #comment5
            34
            #comment6
        ";
        var parser = new SectionsParser();
        string[] unexpected1 = 
        [
            "#comment1",
            "#comment2",
            "#comment3",
            "#comment4"
        ];
        string[] unexpected2 = ["#comment5", "#comment6"];

        // Act
        var sections = parser.Parse(data);

        // Assert
        sections["section1"].Should().NotContain(unexpected1);
        sections["section2"].Should().NotContain(unexpected2);
    }

    [TestMethod]
    [DataRow(@"
        [section1]
                          
    ")]
    [DataRow(@"
        [section1]
        12
        24
        [section2]
        [section3]
        15
        26  
    ")]
    [DataRow(@"
        [section1]
        12
        24
        [section2]
        15
        67
        [section3]
    ")]
    public void Parse_WhenSectionHasNoData_ShouldThrowParserException(string data)
    {
        // Arrange
        var parser = new SectionsParser();
        var expectedSubstring = $"*{ExceptionMessages.SectionWithoutDataMessage}*";

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ParserException>()
           .WithMessage(expectedSubstring);
    }

    [TestMethod]
    [DataRow(@"
        []
        15
        67
    ")]
    [DataRow(@"
        [       ]
        15
        78
    ")]
    public void Parse_WhenSectionNameIsEmpty_ShouldThrowParserException(string data)
    {
        // Arrange
        var parser = new SectionsParser();
        var expectedSubstring = $"*{ExceptionMessages.SectionNameIsEmptyMessage}*";

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ParserException>()
           .WithMessage(expectedSubstring);
    }

    [TestMethod]
    public void Parse_WhenSectionIsRepeated_ShouldThrowParserException()
    {
        // Arrange
        var data = @"  
            [section1]
            12
            24
            [section2]
            15
            67
            [section1]
            15
            78
        ";
        var parser = new SectionsParser();
        var expectedSubstring = $"*{ExceptionMessages.SeccionIsRepeatedMessage}*";

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ParserException>()
           .WithMessage(expectedSubstring);
    }

    [TestMethod]
    public void Parse_WhenAnElementIsNotPartOfAnySection_ShouldThrowParserException()
    {
        // Arrange
        var data = @"  
            Hello World! (this element is not part of any section)
            [section1]
            12
            24
        ";
        var parser = new SectionsParser();
        var expectedSubstring = $"*{ExceptionMessages.ElementThatIsNotPartAnySectionMessage}*";

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ParserException>()
           .WithMessage(expectedSubstring);
    }

    [TestMethod]
    public void Parse_WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var parser = new SectionsParser();
        var data = default(string);

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ArgumentNullException>()
           .WithParameterName(nameof(data));
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow("       ")]
    public void Parse_WhenDataSourceIsEmpty_ShouldThrowParserException(string data)
    {
        // Arrange
        var parser = new SectionsParser();
        var expectedSubstring = $"*{ExceptionMessages.DataSourceIsEmptyMessage}*";

        // Act
        Action act = () => parser.Parse(data);

        // Assert
        act.Should()
           .Throw<ParserException>()
           .WithMessage(expectedSubstring);
    }
}
