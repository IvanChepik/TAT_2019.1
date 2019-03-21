using System;
using System.Collections.Generic;
using Models;

namespace Criterions
{
    public interface IOptimize
    {
        void Optimize(decimal sum, int productivity, List<Employee> employees);
        List<Employee> EmployeesToWork { get; }
    }
}
