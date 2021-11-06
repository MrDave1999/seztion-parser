using SeztionParser.Interfaces;
using System;
using System.Collections.Generic;
using SeztionParser.Providers;
using System.Text;
using System.Globalization;
using SeztionParser.Exceptions;

namespace SeztionParser.Helpers
{
    /// <summary>
    /// Defines operations that serve to convert a section data to another data type.
    /// </summary>
    public static class SectionDataConversion
    {
        /// <summary>
        /// Convert section data to <c>decimal</c>.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the data in the section are not <c>decimals</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The section data in <c>decimal</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static IEnumerable<decimal> ToDecimal(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
        {
            foreach (var data in sections[sectionName])
                yield return decimal.Parse(data, provider ?? CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert section data to <c>doubles</c>.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the data in the section are not <c>doubles</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The section data in <c>double</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static IEnumerable<double> ToDouble(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
        {
            foreach (var data in sections[sectionName])
                yield return double.Parse(data, provider ?? CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert section data to <c>floats</c>.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">If the data in the section are not <c>floats</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The section data in <c>float</c> format.</returns>
        /// <remarks><c>provider</c> is <c>null</c>, the default culture is <see cref="CultureInfo.InvariantCulture" />.</remarks>
        public static IEnumerable<float> ToFloat(this ISectionsData sections, string sectionName, IFormatProvider provider = null)
        {
            foreach (var data in sections[sectionName])
                yield return float.Parse(data, provider ?? CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert section data to <c>integers</c>.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to convert.</param>
        /// <exception cref="FormatException">If the data in the section are not <c>integers</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The section data in <c>integer</c> format.</returns>
        public static IEnumerable<int> ToInt(this ISectionsData sections, string sectionName)
        {
            foreach (var data in sections[sectionName])
                yield return int.Parse(data);
        }

        /// <summary>
        /// Convert section data to <c>longs</c>.
        /// </summary>
        /// <param name="sections">The data of sections.</param>
        /// <param name="sectionName">The name of the section to convert.</param>
        /// <exception cref="FormatException">If the data in the section are not <c>longs</c>.</exception>
        /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
        /// <returns>The section data in <c>long</c> format.</returns>
        public static IEnumerable<long> ToLong(this ISectionsData sections, string sectionName)
        {
            foreach (var data in sections[sectionName])
                yield return long.Parse(data);
        }
    }
}
