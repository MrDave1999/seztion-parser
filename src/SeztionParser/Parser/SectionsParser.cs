using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace SeztionParser;

/// <summary>
/// Defines the operations that control the parser behavior.
/// </summary>
public class SectionsParser : ISectionsParser
{
    /// <inheritdoc />
    public ISectionsData Parse(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
            throw new ParserException(ExceptionMessages.DataSourceIsEmptyMessage);

        var lines = data.Split(NewLine.ToCharArray());
        var sections = new SectionsData();
        SectionData sectionData = null;
        string sectionName = null;
        int len = lines.Length;
        for (int i = 0; i < len; ++i)
        {
            if (string.IsNullOrWhiteSpace(lines[i]) || IsComment(lines[i]))
                continue;
            if (IsSection(ref lines[i]))
            {
                bool isEmptyPreviousSection = sectionData?.Count == 0;
                if (isEmptyPreviousSection)
                    throw new ParserException(ExceptionMessages.SectionWithoutDataMessage, sectionName);

                sectionName = ExtractSection(lines[i]);
                if (string.IsNullOrWhiteSpace(sectionName))
                    throw new ParserException(ExceptionMessages.SectionNameIsEmptyMessage);

                sectionData = new SectionData();
                bool isRepeatedSection = !sections.Add(sectionName, sectionData);
                if (isRepeatedSection)
                    throw new ParserException(ExceptionMessages.SeccionIsRepeatedMessage, sectionName);
            }
            else
            {
                if (sectionData == null)
                    throw new ParserException(ExceptionMessages.ElementThatIsNotPartAnySectionMessage, lines[i]);

                sectionData.Add(lines[i]);
            }
        }
        bool IsEmptyLastSection = sectionData.Count == 0;
        if (IsEmptyLastSection)
            throw new ParserException(ExceptionMessages.SectionWithoutDataMessage, sectionName);

        return sections;
    }

    /// <summary>
    /// Check if the text is a comment.
    /// </summary>
    /// <param name="text">The text to validate.</param>
    /// <returns><c>true</c> if is comment, otherwise <c>false</c>.</returns>
    private bool IsComment(string text)
        => text.TrimStart()[0] == '#';

    /// <summary>
    /// Check if the section has the correct format.
    /// </summary>
    /// <param name="text">The text to validate.</param>
    /// <returns><c>true</c> if the section is correctly format, otherwise <c>false</c>.</returns>
    private bool IsSection(ref string text)
    {
        text = text.Trim();
        return text[0] == '[' && text[text.Length - 1] == ']';
    }

    /// <summary>
    /// Extracts the name of the section.
    /// </summary>
    /// <param name="text">The section to extract.</param>
    /// <returns>The name of the extracted section.</returns>
    private string ExtractSection(string text)
         => text.Substring(1, text.Length - 2);
}
