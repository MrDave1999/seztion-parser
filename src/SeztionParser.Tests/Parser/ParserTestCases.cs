namespace SeztionParser.Tests.Parser;

public class ParserTestCases
{
    public static IEnumerable<string[]> SectionNameIsEmpty
    {
        get
        {
            return
            [
                [
                    """
                    []
                    15
                    67
                    """
                ],
                [
                    """
                    [       ]
                    15
                    78
                    """
                ]
            ];
        }
    }

    public static IEnumerable<string[]> SectionHasNoData
    {
        get
        {
            return
            [
                [
                    """
                    [section1]
                         
                          
                    """
                ],
                [
                    """
                    [section1]
                    [section2]
                    15
                    67
                    [section3]
                    15
                    26  
                    """
                ],
                [
                    """
                    [section1]
                    12
                    24
                    [section2]
                    [section3]
                    15
                    26  
                    """
                ],
                [
                    """
                    [section1]
                    12
                    24
                    [section2]
                    15
                    67
                    [section3]
                    """
                ]
            ];
        }
    }
}
