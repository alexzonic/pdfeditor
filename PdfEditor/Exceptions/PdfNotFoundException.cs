using System;

namespace PdfEditor.Exceptions
{
    public sealed class PdfNotFoundException : Exception
    {
        public PdfNotFoundException(string path) : base($"File {path} doesnt exist")
        {
        }
    }
}