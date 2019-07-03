using System;

namespace DEV_2
{
    public class NotRussianWordException : ApplicationException
    {
        public NotRussianWordException(string message) : base(message)
        {

        }
    }
}