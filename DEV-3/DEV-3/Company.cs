using System.Collections.Generic;
using Criterions;
using Models;

namespace DEV_3
{
    public class Company
    {
        const int CountOfJuniors = 15;
        const int CountOfMiddles = 10;
        const int CountOfSeniors = 7;
        const int CountOfLeads = 5;
        private readonly List<Employee> allEmployees = new List<Employee>();
        public IOptimize Optimization { private get; set; }
        public decimal Sum { get; private set; }
        public int Productivity { get; private set; }
        public int JuniorsOnProject { get; set; }
        public int MiddlesOnProject { get; set; }
        public int SeniorsOnProject { get; set; }
        public int LeadsOnProject { get; set; }
        public Company(IOptimize optimization, decimal sum, int productivity)
        {
            InitEmployeesByJuniors();
            InitEmployeesByMiddles();
            InitEmployeesBySeniors();
            InitEmployeesByLeads();
            Optimization = optimization;
            Sum = sum;
            Productivity = productivity;
        }
        public void Optimize()
        {
            Optimization.Optimize(Sum, Productivity, allEmployees);
            CountQuantityEmp();
        }
        private void InitEmployeesByJuniors()
        {
            for(int i = 0; i < CountOfJuniors; i++)
            {
                allEmployees.Add(new Junior());
            }
        }
        private void InitEmployeesByMiddles()
        {
            for (int i = 0; i < CountOfMiddles; i++)
            {
                allEmployees.Add(new Middle());
            }
        }
        private void InitEmployeesBySeniors()
        {
            for (int i = 0; i < CountOfSeniors; i++)
            {
                allEmployees.Add(new Senior());
            }
        }
        private void InitEmployeesByLeads()
        {
            for (int i = 0; i < CountOfLeads; i++)
            {
                allEmployees.Add(new Lead());
            }
        }
        private void CountQuantityEmp()
        {
            foreach (var emp in Optimization.EmployeesToWork)
            {
                if (emp is Lead)
                {
                    LeadsOnProject++;
                    continue;
                }
                if (emp is Senior)
                {
                    SeniorsOnProject++;
                    continue;
                }
                if (emp is Middle)
                {
                    MiddlesOnProject++;
                    continue;
                }
                if (emp is Junior)
                {
                    JuniorsOnProject++;
                    continue;
                }
            }
        }
    }
}
