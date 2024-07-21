using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace SeztionParser;

/// <inheritdoc cref="ISectionData" />
class SectionData : ISectionData
{
    /// <summary>
    /// Allows access to the data of a specific section.
    /// </summary>
    /// <value>
    /// The list with the data of a specific section.
    /// </value>
    private readonly List<string> section = new List<string>(16);

    /// <summary>
    /// Adds an element in the section.
    /// </summary>
    /// <param name="item">The item to add in the section.</param>
    public void Add(string item)
        => section.Add(item);

    /// <inheritdoc />
    public string this[int index] => section[index];

    /// <inheritdoc />
    public int Count => section.Count;

    /// <inheritdoc />
    public bool Contains(string item) 
        => section.Contains(item);

    /// <summary>
    /// Returns an enumerator used to traverse the data of a specified section.
    /// </summary>
    /// <returns>An enumerator used to traverse the data of a specified section.</returns>
    public IEnumerator<string> GetEnumerator()
        => section.GetEnumerator();

    /// <summary>
    /// Returns an enumerator used to traverse the data of a specified section.
    /// </summary>
    /// <returns>An enumerator used to traverse the data of a specified section.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Converts the <see cref="SectionData" /> instance to a <see cref="String" /> object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        if (Count > 1)
        {
            var sb = new StringBuilder();
            sb.Append($"[{NewLine}");
            foreach (var data in this)
                sb.Append($"   {data}{NewLine}");
            sb.Append($"]{NewLine}");
            return sb.ToString();
        }
        return Count == 0 ? $"[]{NewLine}" : $"[{this[0]}]{NewLine}";
    }
}
