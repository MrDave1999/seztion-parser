using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeztionParser.Constants;
using SeztionParser.Exceptions;
using SeztionParser.Providers;

namespace SeztionParser.Tests
{
    [TestClass]
    public class SectionsParserTests
    {
        /// <summary>
        /// Check if the exception is throw with a specific message.
        /// </summary>
        private void CheckMessageException(string sections, string message)
        {
            // Arrange
            var parser = new SectionsParser();

            // Act
            try
            {
                parser.Parse(sections);
            }
            catch (ParserException e)
            {
                // Assert
                StringAssert.Contains(e.Message, message);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

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

            // Act
            var sections = parser.Parse(data);

            // Assert
            var sectionNames = sections.GetNames();
            Assert.IsTrue(sectionNames.Contains("section1"));
            Assert.IsTrue(sectionNames.Contains("section2"));
            Assert.IsTrue(sectionNames.Contains("section3"));
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

            // Act
            var sections = parser.Parse(data);

            // Assert
            var section1 = sections["section1"];
            var section2 = sections["section2"];
            Assert.IsTrue(section1.Contains("1"));
            Assert.IsTrue(section1.Contains("2"));
            Assert.IsTrue(section1.Contains("3"));
            Assert.IsTrue(section1.Contains("4"));
            Assert.IsTrue(section2.Contains("1"));
            Assert.IsTrue(section2.Contains("2"));
            Assert.IsTrue(section2.Contains("3"));
            Assert.IsTrue(section2.Contains("4"));
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
            var section1 = sections["section1"];
            var section2 = sections["section2"];
            Assert.IsFalse(section1.Contains("#comment1"));
            Assert.IsFalse(section1.Contains("#comment2"));
            Assert.IsFalse(section1.Contains("#comment3"));
            Assert.IsFalse(section1.Contains("#comment4"));
            Assert.IsFalse(section2.Contains("#comment5"));
            Assert.IsFalse(section2.Contains("#comment6"));
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
            CheckMessageException(data, ExceptionMessages.SectionWithoutDataMessage);
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
            CheckMessageException(data, ExceptionMessages.SectionNameIsEmptyMessage);
        }

        [TestMethod]
        public void Parse_WhenTheSectionIsRepeated_ShouldThrowParserException()
        {
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
            CheckMessageException(data, ExceptionMessages.SeccionIsRepeatedMessage);
        }

        [TestMethod]
        public void Parse_WhenAnElementIsNotPartOfAnySection_ShouldThrowParserException()
        {
            string data = @"  
                Hello World! (this element is not part of any section)
                [section1]
                12
                24
            ";
            CheckMessageException(data, ExceptionMessages.ElementThatIsNotPartAnySectionMessage);
        }

        [TestMethod]
        [DataRow("       ")]
        [DataRow("")]
        public void Parse_WhenTheDataSourceIsEmpty_ShouldThrowParserException(string data)
        {
            CheckMessageException(data, ExceptionMessages.DataSourceIsEmptyMessage);
        }
    }
}
