namespace SeztionParser.Tests;

[TestClass]
public class SectionsParserTests
{
    [TestMethod]
    public void Parse_WhenReadAValidSection_ShouldGetsSectionName()
    {
        // Arrange
        string data = @"
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
        var expected = new[] { "section1", "section2", "section3" };

        // Act
        var sections = parser.Parse(data);
        var sectionNames = sections.GetNames();

        // Assert
        sectionNames.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void Parse_WhenNotReadASection_ShouldGetItemOfSection()
    {
        string data = @"
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
        var expected = new[] { "1", "2", "3", "4" };

        // Act
        var sections = parser.Parse(data);

        // Assert
        sections["section1"].Should().Contain(expected);
        sections["section2"].Should().Contain(expected);;
    }

    [TestMethod]
    public void Parse_WhenReadAComment_ShouldIgnoreTheComment()
    {
        // Arrange
        string data = @"
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

        // Act
        var sections = parser.Parse(data);

        // Assert
        sections["section1"].Should().NotContain(new[] 
        { 
            "#comment1", 
            "#comment2", 
            "#comment3", 
            "#comment4" 
        });
        sections["section2"].Should().NotContain(new [] { "#comment5", "#comment6" });
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
    public void Parse_WhenTheSectionNameIsEmpty_ShouldThrowParserException(string data)
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
    public void Parse_WhenTheSectionIsRepeated_ShouldThrowParserException()
    {
        // Arrange
        string data = @"  
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
        string data = @"  
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
    [DataRow("       ")]
    [DataRow("")]
    public void Parse_WhenTheDataSourceIsEmpty_ShouldThrowParserException(string data)
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
