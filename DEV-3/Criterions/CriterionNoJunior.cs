using Models;
using System.Collections.Generic;
using System.Linq;
namespace Criterions
{
    /// <summary>
    /// class CriterionMinCoast
    /// implement finding of quantity and type employees
    /// for fix product and min cost without Junior 
    /// </summary>
    public class CriterionNoJunior : IOptimize
    {
        public List<Employee> EmployeesToWork { get; } = new List<Employee>();

        /// <summary>
        /// method Optimize
        /// is called from company and make a team 
        /// with min value of product and fix product without juniors
        /// </summary>
        /// <param name="sum">value of necessary product</param>
        /// <param name="employees">list of all employees</param>
        public void Optimize(decimal productivity, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            employees = RemoveAllJuniors(employees);
            var afterSum = SelectEmployeeForMinCoast(employees, productivity);
        }

        private List<Employee> RemoveAllJuniors(List<Employee> employees)
        {
            return employees.Where(e => !(typeof(Junior) == e.GetType())).ToList();
        }

        private List<Employee> SortByCoef(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.Coef).ToList();
        }

        /// <summary>
        /// method SelectEmployeeForMinCoast
        /// add employees in list for min cost
        /// </summary>
        /// <param name="employees">list of all employees in company sorted by coef without juniors</param>
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

    }
}
