using System;

namespace DEV_2
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var phoneticConverter = new PhoneticConverter();
            Console.WriteLine(phoneticConverter.GetPhoneticRepresentation(args[0]));
        }
    }
}
