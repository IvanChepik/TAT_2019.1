using System;

namespace DEV_1
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var stringConverter = new StringConverter();
            var maxUniqueSequences = stringConverter.GetMaxUniqueSequences("accesserasdfgassfgadd");
            foreach (var value in maxUniqueSequences)
            {
                Console.WriteLine(value);
            }
            Console.Read();
        }
    }
}