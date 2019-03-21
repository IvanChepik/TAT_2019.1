using Models;
using System.Collections.Generic;
using System;
namespace Criterions
{
    public class CriterionJunior : IOptimize
    {
        public List<Employee> EmployeesToWork => throw new NotImplementedException();

        public void Optimize(decimal sum, int productivity, List<Employee> employees)
        {
            Console.WriteLine("Criterion Junior - {0} - {1}", sum, productivity);
        }
        
        
    }
}
