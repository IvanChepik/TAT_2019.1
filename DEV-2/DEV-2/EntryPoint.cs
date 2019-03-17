using System;

namespace DEV_2
{
    class EntryPoint
    {
        /// Class EntryPoint 
        /// Takes 1 argument(string) from the command line and 
        /// search phonetic representation 
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentException("You haven't arguments.");
                }
                var phoneticConverter = new PhoneticConverter();
                Console.WriteLine(phoneticConverter.GetPhoneticRepresentation(args[0]));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}!");
            }
        }
    }
}
