using System;

namespace Flying
{
    public class ObjectIDontFlyException : ApplicationException
    {
        public ObjectIDontFlyException(string message) : base(message)
        {

        }
    }
}