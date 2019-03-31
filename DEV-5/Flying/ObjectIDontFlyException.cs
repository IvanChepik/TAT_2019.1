using System;

namespace Flying
{
    /// <summary>
    /// Class ObjectDontFlyException
    /// thrown when called method GetFlyTime while object don't in flight.
    /// </summary>
    public class ObjectIDontFlyException : ApplicationException
    {
        public ObjectIDontFlyException(string message) : base(message)
        {

        }
    }
}