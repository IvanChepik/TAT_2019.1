using System;

namespace DEV_1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var stringConverter = new StringConverter();
            var allUniqueSequences = stringConverter.GetAllUniqueSequences("access");           
            foreach (var value in allUniqueSequences)
            {
                Console.WriteLine(value);
            }
            Console.Read();
        }
    }
}