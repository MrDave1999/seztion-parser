using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser;

/// <summary>
/// The exception that is thrown when the specified section does not exist in the collection.
/// </summary>
public class SectionNotFoundException : ArgumentException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SectionNotFoundException" /> class with a default message.
    /// </summary>
    public SectionNotFoundException() : base(ExceptionMessages.SectionNotFoundDefaultMessage)
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SectionNotFoundException" /> class with a specified error message and the name of the parameter that causes this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    public SectionNotFoundException(string message, string paramName) : base(message, paramName)
    {

    }
}
