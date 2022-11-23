using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser.Interfaces;

/// <summary>
/// Represents a collection of data from a specific section.
/// </summary>
public interface ISectionData : IEnumerable<string>
{
    /// <summary>
    /// Gets an element of a section at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get from a section.</param>
    /// <value>The element of a section at the specified index.</value>
    string this[int index] { get; }

    /// <summary>
    /// Gets the number of elements in a section.
    /// </summary>
    /// <value>The number of elements contained in the section.</value>
    int Count { get; }

    /// <summary>
    /// Determine if the item is in the section.
    /// </summary>
    /// <param name="item">The item to locate in the section.</param>
    /// <returns><c>true</c> if item is found in the section; otherwise, <c>false</c>.</returns>
    bool Contains(string item);
}
