using Models;
using System.Linq;
using System.Collections.Generic;
namespace Criterions
{
    /// <summary>
    /// class CriterionMinCoast
    /// implement finding of quantity and type employees
    /// for fix product and min cost
    /// </summary>
    public class CriterionMinCoast : IOptimize
    {
        public List<Employee> EmployeesToWork { get; } = new List<Employee>();

        /// <summary>
        /// method Optimize
        /// is called from company and make a team 
        /// with min value of product and fix product
        /// </summary>
        /// <param name="sum">value of necessary product</param>
        /// <param name="employees">list of all employees</param>
        public void Optimize(decimal productivity, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            SelectEmployeeForMinCoast(employees, productivity);
        }

        /// <summary>
        /// method SelectEmployeeForMinCoast
        /// add employees in list for min cost
        /// </summary>
        /// <param name="employees">list of all employees in company sorted by coef</param>
        /// <param name="productivity">productivity of min cost</param>
        /// <returns>return value of cost</returns>
        private decimal SelectEmployeeForMinCoast(List<Employee> employees, decimal productivity)
        {
            var sumCoast = 0.0m;
            foreach (var emp in employees)
            {
                if (productivity - emp.Productivity >= 0)
                {
                    productivity -= emp.Productivity;
                    sumCoast += emp.Sum;
                    EmployeesToWork.Add(emp);
                }
            }
            return sumCoast;
        }

        private List<Employee> SortByCoef(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.Coef).ToList();
        }

    }
}
