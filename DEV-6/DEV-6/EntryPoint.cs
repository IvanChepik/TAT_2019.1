using System;

namespace DEV_6
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var s = new XmlCarParser();

            var sas = s.GetGarFromDocument("Cars.xml");

            foreach (var ers in sas)
            {
                Console.WriteLine(ers.Brand);
            }
        }
    }
}
