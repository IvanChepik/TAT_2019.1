using Models;
using System.Linq;
using System.Collections.Generic;

namespace Criterions
{
    /// <summary>
    /// Class CriterionMaxProduct
    /// implement finding of quantity and type employees
    /// for fix cost and max product.
    /// </summary>
    public class CriterionMaxProduct : IOptimize
    {
        public List<Employee> EmployeesToWork { get; } = new List<Employee>();

        /// <summary>
        /// Method Optimize
        /// is called from company and make a team 
        /// with max value of product and fix cost.
        /// </summary>
        /// <param name="sum">value of necessary cost</param>
        /// <param name="employees">list of all employees</param>
        public void Optimize(decimal sum, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            SelectEmployeeForMaxProductivity(employees, sum);

            if (EmployeesToWork.Count == 0)
            {
                throw new WorkCannotBeExecutedException("Don't enough money even for one employee");
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

        /// <summary>
        /// Method SelectEmployeeForMaxProductivity
        /// add employees in list for max Productivity.
        /// </summary>
        /// <param name="employees">list of all employees in company sorted by coef</param>
        /// <param name="sum">cost of max productivity</param>
        /// <returns>return value of productivity</returns>
        private void SelectEmployeeForMaxProductivity(List<Employee> employees, decimal sum)
        {         
            foreach(var emp in employees)
            {
                if (sum - emp.Sum >= 0)
                {
                    sum -= emp.Sum;
                    EmployeesToWork.Add(emp);
                }
            }
        }

    }
}
