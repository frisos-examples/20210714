using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class DepartmentHandler : IDepartmentHandler
    {
        private IEnumerable<Department> departments;

        public DepartmentHandler(IOptions<IEnumerable<Department>> departmentOptions)
        {
            if (departmentOptions is null)
            {
                throw new ArgumentNullException(nameof(departmentOptions));
            }

            //departments = departmentOptions.Value;

            departments = new List<Department> {
                new Department
                {
                    Name = "Mail",
                    MaxWeight = 1
                },
                new Department
                {
                    Name = "Regular",
                    MinWeight = 1,
                    MaxWeight = 10
                },
                new Department
                {
                    Name = "Heavy",
                    MinWeight = 10
                },
                new Department
                {
                    Name = "Insurance",
                    MinValue = 1000
                },
            };
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
