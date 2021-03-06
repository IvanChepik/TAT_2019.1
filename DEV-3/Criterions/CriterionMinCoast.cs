﻿using Models;
using System.Linq;
using System.Collections.Generic;
namespace Criterions
{
    /// <summary>
    /// Class CriterionMinCoast
    /// implement finding of quantity and type employees
    /// for fix product and min cost
    /// </summary>
    public class CriterionMinCoast : IOptimize
    {
        public List<Employee> EmployeesToWork { get; } = new List<Employee>();

        /// <summary>
        /// Method Optimize
        /// is called from company and make a team 
        /// with min value of product and fix product.
        /// </summary>
        /// <param name="productivity">value of necessary product</param>
        /// <param name="employees">list of all employees</param>
        public void Optimize(decimal productivity, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            SelectEmployeeForMinCoast(employees, productivity);
        }

        /// <summary>
        /// Method SelectEmployeeForMinCoast
        /// add employees in list for min cost.
        /// </summary>
        /// <param name="employees">list of all employees in company sorted by coef</param>
        /// <param name="productivity">productivity of min cost</param>
        /// <returns>return value of cost</returns>
        private void SelectEmployeeForMinCoast(List<Employee> employees, decimal productivity)
        {
            foreach (var emp in employees)
            {
                if (productivity - emp.Productivity >= 0)
                {
                    productivity -= emp.Productivity;
                    EmployeesToWork.Add(emp);
                }
            }
        }

        /// <summary>
        /// Method SortByCoef
        /// it's sorts list of all employees by coef
        /// for the max value in cost/productivity.
        /// </summary>
        /// <param name="employees">list of all employees</param>
        /// <returns>sorted list</returns>
        private List<Employee> SortByCoef(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.Coef).ToList();
        }

    }
}
