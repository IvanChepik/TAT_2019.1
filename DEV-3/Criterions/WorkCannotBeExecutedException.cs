using System;

namespace Criterions
{
    /// <summary>
    /// Class WorkCannotBeExecutedException
    /// thrown when don't enough money or don't enough employees
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
