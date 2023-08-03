using System;

namespace PdfEditor.Exceptions
{
    public sealed class PdfPagesSoLessException : Exception
    {
        public PdfPagesSoLessException(string message) : base(message)
        {
        }
    }
}