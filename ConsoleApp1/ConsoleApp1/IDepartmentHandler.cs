using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IDepartmentHandler
    {
        public bool GetDepartmentByWeight(decimal weight, out Department department);
        public bool GetDepartmentByValue(decimal value, out Department department);
    }
}
