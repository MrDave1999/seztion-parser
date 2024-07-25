using System;
using System.Collections.Generic;
using System.Text;

namespace SeztionParser;

/// <summary>
/// The exception that is thrown when the parser finds an error during the parsing, such as a duplicate section.
/// </summary>
public class ParserException : Exception
{
    private readonly object _actualValue;

    /// <summary>
    /// Allows access to the actual value causing the exception.
    /// </summary>
    public object ActualValue => _actualValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParserException" /> class with a default message.
    /// </summary>
    public ParserException() : base(ExceptionMessages.ParserDefaultMessage)
    {
        
    }

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
        _actualValue = actualValue;
    }

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message
        => _actualValue != null ? 
            base.Message + $" ({ExceptionMessages.ActualValue}: {_actualValue})" : 
            base.Message;
}