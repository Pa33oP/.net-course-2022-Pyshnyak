using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;

namespace Services
{
    public class EmployeeService
    {
        public List<Employee> AddingEmployeeToList(List<Employee> employees, Employee employee)
        {
            if (employee.Date.Year > 2004)
                throw new AgeLimitException("Кандидату на работу нет 18ти лет!");

            if (employee.PassportId == 0)
                throw new PassportIdException("У кандидата на работу нет паспорта!");

            employees.Add(employee);

            return employees;
        }
    }
}
