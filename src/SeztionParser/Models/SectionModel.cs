using SeztionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace SeztionParser.Models;

/// <summary>
/// Represents a section.
/// </summary>
public struct SectionModel
{
    private string name;
    private ISectionData data;

    /// <summary>
    /// Allows access to the section name.
    /// </summary>
    /// <value>
    /// The name of the section.
    /// </value>
    public string Name => name;

    /// <summary>
    /// Allows access to the section data.
    /// </summary>
    /// <value>
    /// An collection of section data.
    /// </value>
    public ISectionData Data => data;

    /// <summary>
    /// Initializes a new instance of the <see cref="SectionModel" /> structure with the specified name and data.
    /// </summary>
    /// <param name="name">The name of the section.</param>
    /// <param name="data">The section data.</param>
    public SectionModel(string name, ISectionData data)
    {
        this.name = name;
        this.data = data;
    }

    /// <summary>
    /// Deconstructs the current <see cref="SectionModel" />.
    /// </summary>
    /// <param name="name">The section name of the current <see cref="SectionModel" />.</param>
    /// <param name="data">The sections data of the current <see cref="SectionModel" />.</param>
    public void Deconstruct(out string name, out ISectionData data)
    {
        name = Name;
        data = Data;
    }

    /// <summary>
    /// Converts the <see cref="SectionModel" /> instance to a <see cref="String" /> object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() =>
        $"Section: {Name} ->{(Data.Count > 1 ? NewLine : " ")}{Data}";
}
