using System;

namespace PdfEditor.Engine.Exceptions;

public sealed class PdfPagesSoLessException : Exception
{
    public PdfPagesSoLessException(string message) : base(message)
    {
    }
}