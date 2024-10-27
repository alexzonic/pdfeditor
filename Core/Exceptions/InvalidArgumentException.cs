using System;

namespace PdfEditor.Core.Exceptions;

public sealed class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string message) : base(message)
    {
    }
}