using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeService
    {
        private List<Employee> _employees = new List<Employee>(); 
        
        public void AddEmployee(Employee employee)
        {
            if (employee.Date.Year > 2004)
                throw new AgeLimitException("Кандидату на работу нет 18ти лет!");

            if (employee.PassportId == 0)
                throw new PassportIdException("У кандидата на работу нет паспорта!");

            _employees.Add(employee);
        }
    }
}
