using SeztionParser.Exceptions;
using SeztionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SeztionParser.Helpers
{
    /// <summary>
    /// Defines operations used to gets the first line of a section in a specific format.
    /// </summary>
    public static class SingleLineSection
    {
        /// <summary>
        /// Gets the first line of the section in <c>decimal</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the first line is not an <c>decimal</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>decimal</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static decimal GetFirstLineDecimal(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
            => decimal.Parse(sections[sectionName][0], provider ?? CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the first line of the section in <c>double</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the first line is not an <c>double</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>double</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static double GetFirstLineDouble(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
            => double.Parse(sections[sectionName][0], provider ?? CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the first line of the section in <c>float</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the first line is not an <c>float</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>float</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static float GetFirstLineFloat(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
            => float.Parse(sections[sectionName][0], provider ?? CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the first line of the section in <c>integer</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <exception cref="FormatException">If the first line is not an <c>integer</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>integer</c> format.</returns>
        public static int GetFirstLineInt(this ISectionsData sections, string sectionName)
            => int.Parse(sections[sectionName][0]);

        /// <summary>
        /// Gets the first line of the section in <c>long</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <exception cref="FormatException">If the first line is not an <c>long</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>long</c> format.</returns>
        public static long GetFirstLineLong(this ISectionsData sections, string sectionName)
            => long.Parse(sections[sectionName][0]);

        /// <summary>
        /// Gets the first line of the section in <c>string</c> format.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to gets in a specific format.</param>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The first line in <c>string</c> format.</returns>
        public static string GetFirstLineString(this ISectionsData sections, string sectionName)
            => sections[sectionName][0];
    }
}
