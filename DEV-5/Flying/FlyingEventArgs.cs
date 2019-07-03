using System;

namespace Flying
{
    /// <summary>
    /// Class FlyingEventArgs
    /// included args for Flied event.
    /// </summary>
    public class FlyingEventArgs : EventArgs
    {
        public string Message { get; }

        /// <summary>
        /// Constructor FlyingEventArgs
        /// set a message for Flied event.
        /// </summary>
        /// <param name="mes"></param>
        public FlyingEventArgs(string mes)
        {
            Message = mes;
        }
    }
}