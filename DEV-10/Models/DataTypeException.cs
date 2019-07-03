using System;

namespace Models
{
    /// <summary>
    /// Class DataTypeException
    /// thrown when data has wrong format
    /// </summary>
    public class DataTypeException : ApplicationException
    {
        public DataTypeException(string message) : base(message)
        {

        }
    }
}