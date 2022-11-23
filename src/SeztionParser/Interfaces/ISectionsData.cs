using System;
using System.Collections.Generic;
using System.Text;
using SeztionParser.Exceptions;
using SeztionParser.Models;

namespace SeztionParser.Interfaces;

/// <summary>
/// Represents a collection of sections.
/// </summary>
public interface ISectionsData : IEnumerable<SectionModel>
{
    /// <summary>
    /// Gets the data of a section.
    /// </summary>
    /// <param name="section">The name of the section to get.</param>
    /// <param name="data">
    /// When this method returns, the data associated with the specified section, if the <c>section</c> is found; otherwise, the default value is <c>null</c>. 
    /// This parameter is passed uninitialized.
    /// </param>
    /// <exception cref="ArgumentNullException"><c>section</c> is <c>null</c>.</exception>
    /// <returns>
    /// <c>true</c> if the section exists, otherwise, returns <c>false</c>.
    /// </returns>
    bool TryGetData(string section, out ISectionData data);

    /// <summary>
    /// Gets the data of a section with the specified section.
    /// </summary>
    /// <param name="section">The name of the section to get.</param>
    /// <exception cref="ArgumentNullException"><c>section</c> is <c>null</c>.</exception>
    /// <exception cref="SectionNotFoundException">If the <c>section</c> does not exist.</exception>
    /// <value>
    /// The collection with the specified section.
    /// </value>
    ISectionData this[string section] { get; }

    /// <summary>
    /// Gets the names of all sections.
    /// </summary>
    /// <returns>The names of all sections.</returns>
    ICollection<string> GetNames();

    /// <summary>
    /// Gets the data from all sections.
    /// </summary>
    /// <returns>The data from all sections.</returns>
    ICollection<ISectionData> GetAll();
}
