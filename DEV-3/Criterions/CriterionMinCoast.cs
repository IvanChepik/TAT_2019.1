﻿using System;
using Models;
using System.Collections.Generic;
namespace Criterions
{
    public class CriterionMinCoast : IOptimize
    {
        public List<Employee> EmployeesToWork => throw new NotImplementedException();

        public void Optimize(decimal sum, int productivity, List<Employee> employees)
        {
            Console.WriteLine("Criterion Min Coast- {0} - {1}", sum, productivity);
        }
    }
}
