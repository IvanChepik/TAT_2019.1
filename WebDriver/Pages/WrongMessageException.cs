using System;

namespace Pages
{
    /// <summary>
    /// WrongMessageException class
    /// thrown when current message is not equals to expected message
    /// </summary>
    public class WrongMessageException : ApplicationException
    {
        public WrongMessageException() : base()
        {

        }
    }
}