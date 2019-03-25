using System;

namespace DEV_1
{
    /// <summary>
    /// Class EntryPoint 
    /// Takes 1 argument(string) from the command line and 
    /// searches for the all sequence with serial unique symbols.
    /// </summary>
    class EntryPoint
    {
        // Method Main 
        // Entry point.
        static void Main(string[] args)
        {
            try
            {
                // Check whether the argument is the more then 0.
                if (args.Length == 0)
                {
                    throw new ArgumentException("You have not used any arguments in the console line.");
                }
                // Checks the argument for correctness.
                if (args[0].Length<2)
                {
                    throw new ArgumentException("Argument length less than two");
                }
                foreach  (var arg in args)
                {
                    foreach (var sequence in arg.SearchAllUniqueSequences())
                    {
                        Console.WriteLine(sequence);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error : {exception.Message}");
            }
        }
    }
}