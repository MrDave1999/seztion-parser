using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static SeztionParser.ExceptionMessages;

namespace SeztionParser;

/// <inheritdoc cref="ISectionsData" />
/// <remarks>
/// This class uses the <see cref="IDictionary{TKey,TValue}" /> interface, where <c>TKey</c> represents 
/// the name of the section and the <c>TValue</c> represents the data of the section.
/// </remarks>
internal class SectionsData : ISectionsData
{
    /// <summary>
    /// Allows access to the data of each section.
    /// </summary>
    /// <value>
    /// The dictionary with the data of each section.
    /// </value>
    private readonly Dictionary<string, ISectionData> _sections = [];

    /// <inheritdoc />
    public ISectionData this[string section]
    {
        get
        {
            if (_sections.TryGetValue(section, out var value))
                return value;
            throw new SectionNotFoundException(SpecifiedSectionDoesNotExistMessage, nameof(section));
        }
    }

    /// <summary>
    /// Adds data to a section.
    /// </summary>
    /// <param name="section">The name of the section to add.</param>
    /// <param name="data">The data to be added to the section.</param>
    /// <returns><c>true</c> if the data can be added, otherwise <c>false</c>.</returns>
    /// <remarks>
    /// If the data cannot be added, it is because the <c>section</c> parameter is <c>null</c> or the section already exists in the collection.
    /// </remarks>
    public bool Add(string section, ISectionData data)
    {
        try
        {
            _sections.Add(section, data);
            return true;
        }
        catch(ArgumentException)
        {
            return false;
        }
    }

    /// <inheritdoc />
    public bool TryGetData(string section, out ISectionData data)
        => _sections.TryGetValue(section, out data);

    /// <inheritdoc />
    public ICollection<string> GetNames()
        => _sections.Keys;

    /// <inheritdoc />
    public ICollection<ISectionData> GetAll()
        => _sections.Values;

    /// <summary>
    /// Return an enumerator used to traverse all sections of the collection.
    /// </summary>
    /// <returns>An enumerator used to traverse all sections of the collection.</returns>
    public IEnumerator<SectionModel> GetEnumerator()
    {
        foreach(var section in _sections)
            yield return new SectionModel(section.Key, section.Value);
    }

    /// <summary>
    /// Return an enumerator used to traverse all sections of the collection.
    /// </summary>
    /// <returns>An enumerator used to traverse all sections of the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    /// <summary>
    /// Converts the <see cref="SectionsData" /> instance to a <see cref="String" /> object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach(var section in this)
            sb.Append(section.ToString());
        return sb.ToString();
    }
}
