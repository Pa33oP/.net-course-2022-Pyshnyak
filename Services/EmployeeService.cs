using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;
using System.Linq;

namespace Services
{
    public class EmployeeService
    {
        //private List<Employee> _employees = new List<Employee>(); 

        //public void AddEmployee(Employee employee)
        //{
        //    if (employee.Date.Year > 2004)
        //        throw new AgeLimitException("Кандидату на работу нет 18ти лет!");

        //    if (employee.PassportId == 0)
        //        throw new PassportIdException("У кандидата на работу нет паспорта!");

        //    _employees.Add(employee);
        //}

        private EmployeeStorage _employeeStorage;

        public EmployeeService(EmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeStorage.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var newEmployeeList = from employee in _employeeStorage._employeeList
                                where employee.Date.Year >= 1992 && employee.Date.Year <= 1995
                                select employee;

            newEmployeeList = from employee in newEmployeeList.ToList()
                            where employee.FirstName.Contains("А")
                            select employee;

            newEmployeeList = from employee in newEmployeeList
                            where employee.Salary.ToString().Contains("7")
                            select employee;

            newEmployeeList = from employee in newEmployeeList
                            where employee.PassportId.ToString().Contains("5")
                            select employee;

            return newEmployeeList;
        }
    }
}
