using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class EmployeeStorage
    {
        public readonly List<Employee> _employeeList = new List<Employee>();
        public void Add(Employee employee)
        {
            _employeeList.Add(employee);
        }
    }
}
