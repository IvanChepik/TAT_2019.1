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
                // Check whether the argument is the only one.
                if (args.Length != 1)
                {
                    if (args.Length == 0)
                    {
                        throw new ArgumentException("You have not used any arguments in the console line.");
                    }

                    throw new ArgumentException($"You used {args.Length} arguments instead of 1 argument.");
                }
                // Checks the argument for correctness.
                if (args[0].Length<2)
                {
                    throw new ArgumentException("Argument length less than two");
                }
                var stringConverter = new StringConverter();
                var allUniqueSequences = stringConverter.GetAllUniqueSequences(args[0]);
                foreach (var sequence in allUniqueSequences)
                {
                    Console.WriteLine(sequence);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"Error : {exception.Message}");
            }
        }
    }
}