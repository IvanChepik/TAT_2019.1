using System;

namespace Flying
{
    public class FlyingEventArgs : EventArgs
    {
        public string Message { get; }

        public FlyingEventArgs(string mes)
        {
            Message = mes;
        }
    }
}