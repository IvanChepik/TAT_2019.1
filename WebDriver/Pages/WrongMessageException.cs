using System;

namespace Pages
{
    /// <summary>
    /// class WrongMessageException
    /// thrown when current message is not equals to expected message
    /// </summary>
    public class WrongMessageException : ApplicationException
    {
        public WrongMessageException() : base()
        {

        }
    }
}