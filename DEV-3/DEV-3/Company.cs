using System.Collections.Generic;
using Criterions;
using System;
using Models;

namespace DEV_3
{
    /// <summary>
    /// Class Company
    /// It's a context which have a ref on IOptimize object 
    /// and connected with it by agregation.
    /// </summary>
    public class Company
    {
        const int CountOfJuniors = 15;
        const int CountOfMiddles = 10;
        const int CountOfSeniors = 7;
        const int CountOfLeads = 5;
        private readonly List<Employee> allEmployees = new List<Employee>();
        public IOptimize Optimization { private get; set; }
        public decimal Сondition { get; private set; }
        public int JuniorsOnProject { get; set; }
        public int MiddlesOnProject { get; set; }
        public int SeniorsOnProject { get; set; }
        public int LeadsOnProject { get; set; }

        public Company(IOptimize optimization, decimal condition)
        {
            InitEmployeesByJuniors();
            InitEmployeesByMiddles();
            InitEmployeesBySeniors();
            InitEmployeesByLeads();
            Optimization = optimization;
            Сondition = condition;
        }

        /// <summary>
        /// Method Optimize
        /// calls a function Optimize in object IOptimize
        /// and count quantity of employees. 
        /// </summary>
        public void Optimize()
        {
            try
            { 
                Optimization.Optimize(Сondition, allEmployees);
                CountQuantityEmp();
            }
            catch (WorkCannotBeExecutedException e)
            {
                throw new WorkCannotBeExecutedException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// InitEmployees methods is a hard code 
        /// this list can be easily replaced by database.
        /// </summary>
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

        /// <summary>
        /// Method CountQuantityEmp
        /// this method count quantity of each employees type.
        /// in final project list.
        /// </summary>
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
