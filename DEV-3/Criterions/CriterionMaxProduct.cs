using Models;
using System.Linq;
using System.Collections.Generic;


namespace Criterions
{
    public class CriterionMaxProduct : IOptimize
    {
        public List<Employee> EmployeesToWork { get; } = new List<Employee>();

        public void Optimize(decimal sum, List<Employee> employees)
        {
            employees = SortByCoef(employees);
            SelectEmployeeForMaxProductivity(employees, sum);
        }

        private List<Employee> SortByCoef(List<Employee> employees)
        {
            return employees.OrderByDescending(x => x.Coef).ToList();
        }
        private decimal SelectEmployeeForMaxProductivity(List<Employee> employees, decimal sum)
        {
            var sumProduct = 0.0m;           
            foreach(var emp in employees)
            {
                if (sum - emp.Sum >= 0)
                {
                    sum -= emp.Sum;
                    sumProduct += emp.Productivity;
                    EmployeesToWork.Add(emp);
                }
            }
            return sumProduct;
        }
    }
}
