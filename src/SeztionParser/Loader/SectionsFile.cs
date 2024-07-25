using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeztionParser;

/// <summary>
/// Represents the loader for the reading of files with sections.
/// </summary>
public static class SectionsFile 
{
    /// <summary>
    /// Loads the sections file.
    /// </summary>
    /// <param name="path">The path of the file to load.</param>
    /// <returns>An instance with the data of each section.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="path"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ParserException">If the parser find an error during the parsing.</exception>
    public static ISectionsData Load(string path)
    {
        ThrowHelper.ThrowIfNull(path, nameof(path));
        var data = File.ReadAllText(path);
        return new SectionsParser().Parse(data);
    }

    /// <summary>
    /// Loads the sections file with the specified encoding.
    /// </summary>
    /// <param name="path">The path of the file to load.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns>An instance with the data of each section.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="path"/> or <paramref name="encoding"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ParserException">If the parser find an error during the parsing.</exception>
    public static ISectionsData Load(string path, Encoding encoding)
    {
        ThrowHelper.ThrowIfNull(path, nameof(path));
        ThrowHelper.ThrowIfNull(encoding, nameof(encoding));
        var data = File.ReadAllText(path, encoding);
        return new SectionsParser().Parse(data);
    }
}
