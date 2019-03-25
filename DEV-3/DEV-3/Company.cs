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
        private const int CountOfJuniors = 15;
        private const int CountOfMiddles = 10;
        private const int CountOfSeniors = 7;
        private const int CountOfLeads = 5;
        private readonly List<Employee> _allEmployees = new List<Employee>();
        public IOptimize Optimization { private get; set; }
        public decimal Сondition { get; }
        public int JuniorsOnProject { get; set; }
        public int MiddlesOnProject { get; set; }
        public int SeniorsOnProject { get; set; }
        public int LeadsOnProject { get; set; }

        /// <summary>
        /// Constructor Company
        /// init list of all employees and install criterion and condition of this criterion.
        /// </summary>
        /// <param name="optimization">criterion of optimize</param>
        /// <param name="condition">condition of criterion</param>
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
                Optimization.Optimize(Сondition, _allEmployees);
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
            for(var i = 0; i < CountOfJuniors; i++)
            {
                _allEmployees.Add(new Junior());
            }
        }

        private void InitEmployeesByMiddles()
        {
            for (var i = 0; i < CountOfMiddles; i++)
            {
                _allEmployees.Add(new Middle());
            }
        }

        private void InitEmployeesBySeniors()
        {
            for (var i = 0; i < CountOfSeniors; i++)
            {
                _allEmployees.Add(new Senior());
            }
        }

        private void InitEmployeesByLeads()
        {
            for (var i = 0; i < CountOfLeads; i++)
            {
                _allEmployees.Add(new Lead());
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
                }

            }
        }
    }
}
