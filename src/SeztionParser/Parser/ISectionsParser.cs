﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser;

/// <summary>
/// Represents the sections parser.
/// </summary>
public interface ISectionsParser
{
    /// <summary>
    /// Starts the parsing to extract the data of each section.
    /// </summary>
    /// <param name="data">Data to parsing.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="data"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ParserException">If the parser find an error during the parsing.</exception>
    /// <returns>An instance with the parsed data.</returns>
    ISectionsData Parse(string data);
}
