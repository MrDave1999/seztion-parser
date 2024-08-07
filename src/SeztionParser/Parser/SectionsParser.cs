﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace SeztionParser;

/// <inheritdoc cref="ISectionsParser" />
public class SectionsParser : ISectionsParser
{
    /// <inheritdoc />
    public ISectionsData Parse(string data)
    {
        ThrowHelper.ThrowIfNull(data, nameof(data));
        if (string.IsNullOrWhiteSpace(data))
            throw new ParserException(ExceptionMessages.DataSourceIsEmptyMessage);

        var lines = data.Split(NewLine.ToCharArray());
        var sections = new SectionsData();
        SectionData sectionData = default;
        string sectionName = string.Empty;
        int len = lines.Length;
        for (int i = 0; i < len; ++i)
        {
            var line = lines[i];

            if (string.IsNullOrWhiteSpace(line) || IsComment(line))
                continue;

            if (IsSection(ref line))
            {
                bool isEmptyPreviousSection = sectionData?.Count == 0;
                if (isEmptyPreviousSection)
                    throw new ParserException(ExceptionMessages.SectionWithoutDataMessage, sectionName);

                sectionName = ExtractSection(line);
                if (string.IsNullOrWhiteSpace(sectionName))
                    throw new ParserException(ExceptionMessages.SectionNameIsEmptyMessage);

                sectionData = [];
                bool isRepeatedSection = !sections.Add(sectionName, sectionData);
                if (isRepeatedSection)
                    throw new ParserException(ExceptionMessages.SeccionIsRepeatedMessage, sectionName);
            }
            else
            {
                if (sectionData is null)
                    throw new ParserException(ExceptionMessages.ElementThatIsNotPartAnySectionMessage, line);

                sectionData.Add(line);
            }
        }
        bool isEmptyLastSection = sectionData.Count == 0;
        if (isEmptyLastSection)
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
