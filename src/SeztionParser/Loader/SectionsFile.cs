using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeztionParser;

/// <summary>
/// Defines the operations that can be applied to a sections file.
/// </summary>
public static class SectionsFile 
{
    /// <inheritdoc cref="File.ReadAllText(string)" path="/exception"></inheritdoc>
    /// <inheritdoc cref="ISectionsParser.Parse" path="/exception"></inheritdoc>
    /// <summary>
    /// Loads the sections file.
    /// </summary>
    /// <param name="path">The path of the file to load.</param>
    /// <returns>An instance with the data of each section.</returns>
    public static ISectionsData Load(string path)
    {
        var data = File.ReadAllText(path);
        return new SectionsParser().Parse(data);
    }

    /// <inheritdoc cref="File.ReadAllText(string)" path="/exception"></inheritdoc>
    /// <inheritdoc cref="ISectionsParser.Parse" path="/exception"></inheritdoc>
    /// <summary>
    /// Loads the sections file with the specified encoding.
    /// </summary>
    /// <param name="path">The path of the file to load.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns>An instance with the data of each section.</returns>
    public static ISectionsData Load(string path, Encoding encoding)
    {
        var data = File.ReadAllText(path, encoding);
        return new SectionsParser().Parse(data);
    }
}
