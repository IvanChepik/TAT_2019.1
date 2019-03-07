using System;

namespace DEV_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringConverter stringConverter = new StringConverter();
            foreach(var value in stringConverter.GetMaxUniqueSequences("access"))
            {
                Console.WriteLine(value);
            }           
        }
    }
}
