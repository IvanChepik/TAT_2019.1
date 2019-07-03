using System;

namespace DEV_6
{
    /// <summary>
    /// Class NoTypeCarException
    /// thrown when type of car is missing.
    /// </summary>
    public class NoTypeCarException : ApplicationException
    {
        public NoTypeCarException(string message) : base(message)
        {

        }
    }
}