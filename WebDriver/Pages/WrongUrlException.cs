using System;

namespace Pages
{
    /// <summary>
    /// Class WrongUrlException
    /// thrown when url is not equals to expected message
    /// </summary>
    public class WrongUrlException : ApplicationException
    {
        public WrongUrlException() : base()
        {

        }
    }
}