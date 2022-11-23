using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser.Constants;

/// <summary>
/// Represents error messages that can be used by the library.
/// </summary>
public class ExceptionMessages
{
    public const string SectionNameIsEmptyMessage = "Parser found an empty section name";
    public const string SectionWithoutDataMessage = "Parser found a section without data"; 
    public const string SpecifiedSectionDoesNotExistMessage = "The specified section does not exist";
    public const string SeccionIsRepeatedMessage = "Parser found a repeated section";
    public const string ElementThatIsNotPartAnySectionMessage = "Parser found an element that is not part of any section";
    public const string DataSourceIsEmptyMessage = "Parser found an empty data source";
}
