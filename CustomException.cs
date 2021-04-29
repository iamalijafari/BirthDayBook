using System;

namespace BirthDayBook
{
    public class InvalidKeyFormatException : FormatException
    {
        public InvalidKeyFormatException(string message)
            : base(message)
        {
        }
    }
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message)
            : base(message)
        {
        }
    }
}
