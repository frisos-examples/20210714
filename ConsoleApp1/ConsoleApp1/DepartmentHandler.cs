using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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

            departments = departmentOptions.Value;
        }

        public bool GetDepartmentByValue(decimal value, out Department department)
        {
            throw new NotImplementedException();
        }

        public bool GetDepartmentByWeight(decimal weight, out Department department)
        {
            throw new NotImplementedException();
        }
    }
}
