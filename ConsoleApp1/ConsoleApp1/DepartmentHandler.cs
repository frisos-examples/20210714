using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class DepartmentHandler : IDepartmentHandler
    {
        private List<Department> departments;

        public DepartmentHandler(IOptions<List<Department>> departmentOptions)
        {
            if (departmentOptions is null)
            {
                throw new ArgumentNullException(nameof(departmentOptions));
            }

            departments = departmentOptions.Value;
        }

        public bool GetDepartmentByValue(decimal value, out Department department)
        {
            department = departments.FirstOrDefault(d =>
                (value > d.MinValue && value <= d.MaxValue) ||
                (value > d.MinValue && !d.MaxValue.HasValue) ||
                value <= d.MaxValue
            );

            return department != null;
        }

        public bool GetDepartmentByWeight(decimal weight, out Department department)
        {
            department = departments.FirstOrDefault(d =>
                (weight > d.MinWeight && weight <= d.MaxWeight) ||
                (weight > d.MinWeight && !d.MaxWeight.HasValue) ||
                weight <= d.MaxWeight 
            );

            return department != null;
        }
    }
}
