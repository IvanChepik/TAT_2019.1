using System;

namespace Criterions
{
    /// <summary>
    /// Class WorkCannotBeExecutedException
    /// thrown when don't enough money 
    /// </summary>
    public class WorkCannotBeExecutedException : ApplicationException
    {
        public WorkCannotBeExecutedException()
        {

        }

        public WorkCannotBeExecutedException(string message) : base(message)
        {

        }

    }
}
