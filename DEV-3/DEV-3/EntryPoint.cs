using System;
using Criterions;

namespace DEV_3
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Company company = new Company(new CriterionMaxProduct(), 10000, 10000);
            company.Optimize();
            Console.WriteLine(company.JuniorsOnProject);
            Console.WriteLine(company.MiddlesOnProject);
            Console.WriteLine(company.SeniorsOnProject);
            Console.WriteLine(company.LeadsOnProject);
        }
    }
}
