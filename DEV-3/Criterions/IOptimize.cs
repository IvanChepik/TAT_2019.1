using System.Collections.Generic;
using Models;

namespace Criterions
{
    /// <summary>
    /// interface IOptimize
    /// this interface includes methods for our criterions
    /// and allows uses methods and properties in independence of choosen criterion
    /// </summary>
    public interface IOptimize
    {
        void Optimize(decimal condition, List<Employee> employees);

        List<Employee> EmployeesToWork { get; }
    }
}
