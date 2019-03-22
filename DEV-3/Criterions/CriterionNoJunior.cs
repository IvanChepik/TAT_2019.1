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

        public void Optimize(decimal productivity, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            employees = RemoveAllJuniors(employees);
            SelectEmployeeForMinCoast(employees, productivity);           
        }
        private List<Employee> RemoveAllJuniors(List<Employee> employees)
        {
            return employees.Where(e => !(typeof(Junior) == e.GetType())).ToList();
        }
        private List<Employee> SortByCoef(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.Coef).ToList();
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
    }
}
