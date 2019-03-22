using System;
using System.Collections.Generic;
using Models;

namespace Criterions
{
    public interface IOptimize
    {
        void Optimize(decimal condition, List<Employee> employees);
        List<Employee> EmployeesToWork { get; }
    }
}
