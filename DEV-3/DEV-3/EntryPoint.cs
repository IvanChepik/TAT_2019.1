using System;
using Criterions;

namespace DEV_3
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Company company = new Company(new CriterionNoJunior(), 10000);
            company.Optimize();
            Console.WriteLine($"Juniors = {company.JuniorsOnProject}");
            Console.WriteLine($"Middles = {company.MiddlesOnProject}");
            Console.WriteLine($"Seniors = {company.SeniorsOnProject}");
            Console.WriteLine($"Leads = {company.LeadsOnProject}");
        }
    }
}
