using System;

namespace DEV_6
{
    /// <summary>
    /// Interface ICommand
    /// Included Event and method execute for all command.
    /// </summary>
    public interface ICommand
    {
        event EventHandler<string> Requested;

        void Execute();
    }
}