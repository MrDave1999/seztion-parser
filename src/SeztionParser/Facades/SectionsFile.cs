using SeztionParser.Interfaces;
using SeztionParser.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeztionParser.Facades;

/// <summary>
/// Defines the operations that can be applied to a sections file.
/// </summary>
public static class SectionsFile 
{
    /// <inheritdoc cref="File.ReadAllText(string)" path="/exception"></inheritdoc>
    /// <inheritdoc cref="ISectionsParser.Parse" path="/exception"></inheritdoc>
    /// <summary>
    /// Load the sections file.
    /// </summary>
    /// <param name="path">The path of the file to load.</param>
    /// <returns>An instance with the data of each section.</returns>
    public static ISectionsData Load(string path)
        => new SectionsParser().Parse(File.ReadAllText(path));
}
