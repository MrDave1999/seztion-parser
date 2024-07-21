using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser;

/// <summary>
/// The exception that is thrown when the parser finds an error during the parsing, such as a duplicate section.
/// </summary>
public class ParserException : Exception
{
    private readonly object actualValue;

    /// <summary>
    /// Allows access to the actual value causing the exception.
    /// </summary>
    public object ActualValue => actualValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ParserException(string message) : base(message)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserException" /> class with a specified error message and the actual value that caused the exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="actualValue">The actual value that caused the exception.</param>
    public ParserException(string message, object actualValue) : base(message)
    {
        this.actualValue = actualValue;
    }

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message
        => actualValue != null ? base.Message + " (Actual Value: " + actualValue + ")" : base.Message;
}