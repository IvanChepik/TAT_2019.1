using System;
using System.IO;
using Newtonsoft.Json;

namespace DEV_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new JsonTextReader(new StreamReader("Test.json")); 
            Console.WriteLine(reader.Value);
            while (reader.Read())
            {
                Console.WriteLine(reader.Value);
            }
        }
    }
}
