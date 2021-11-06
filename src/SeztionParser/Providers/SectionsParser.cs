using SeztionParser.Interfaces;
using static System.Environment;
using SeztionParser.Constants;
using SeztionParser.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser.Providers
{
    /// <summary>
    /// Defines the operations that control the parser behavior.
    /// </summary>
    public class SectionsParser : ISectionsParser
    {
        /// <summary>
        /// Check if the text is a comment.
        /// </summary>
        /// <param name="text">The text to validate.</param>
        /// <returns><c>true</c> if is comment, otherwise <c>false</c>.</returns>
        protected virtual bool IsComment(string text)
            => text.TrimStart()[0] == '#';

        /// <summary>
        /// Check if the section has the correct format.
        /// </summary>
        /// <param name="text">The text to validate.</param>
        /// <returns><c>true</c> if the section is correctly format, otherwise <c>false</c>.</returns>
        protected virtual bool IsSection(ref string text)
        {
            text = text.Trim();
            return text[0] == '[' && text[text.Length - 1] == ']';
        }

        /// <summary>
        /// Extracts the name of the section.
        /// </summary>
        /// <param name="text">The section to extract.</param>
        /// <returns>The name of the extracted section.</returns>
        protected virtual string ExtractSection(string text)
             => text.Substring(1, text.Length - 2);

        /// <inheritdoc />
        public ISectionsData Parse(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw Create(ExceptionMessages.DataSourceIsEmptyMessage);
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
                    bool IsEmptyPreviousSection = sectionData?.Count == 0;
                    if (IsEmptyPreviousSection)
                        throw Create(ExceptionMessages.SectionWithoutDataMessage, sectionName);

                    sectionName = ExtractSection(lines[i]);
                    if (string.IsNullOrWhiteSpace(sectionName))
                        throw Create(ExceptionMessages.SectionNameIsEmptyMessage);
                    sectionData = new SectionData();
                    bool isRepeatedSection = !sections.Add(sectionName, sectionData);
                    if (isRepeatedSection)
                        throw Create(ExceptionMessages.SeccionIsRepeatedMessage, sectionName);
                }
                else
                {
                    if (sectionData == null)
                        throw Create(ExceptionMessages.ElementThatIsNotPartAnySectionMessage, lines[i]);
                    sectionData.Add(lines[i]);
                }
            }
            bool IsEmptyLastSection = sectionData.Count == 0;
            if (IsEmptyLastSection)
                throw Create(ExceptionMessages.SectionWithoutDataMessage, sectionName);
            return sections;
        }

        private Exception Create(string message) => new ParserException(message);
        private Exception Create(string message, object actualValue) => new ParserException(message, actualValue);
    }
}
