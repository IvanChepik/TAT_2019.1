using System;

namespace Materials
{
    /// <summary>
    /// class WrongLengthException
    /// thrown when string more or less than condition
    /// </summary>
    public class WrongLengthException : ApplicationException
    {
        public WrongLengthException(string message) : base(message)
        {

        }
    }
}