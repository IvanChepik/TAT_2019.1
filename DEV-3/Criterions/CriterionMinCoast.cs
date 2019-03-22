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

        public void Optimize(decimal productivity, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            SelectEmployeeForMinCoast(employees, productivity);
        }
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
