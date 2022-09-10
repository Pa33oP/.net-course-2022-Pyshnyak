using Xunit;
using Services;
using Services.Exceptions;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ServiceTests
{
    public class EmployeeServiceTests
    {
        //[Fact]
        //public void EmployeeAgeExceptionsTest()
        //{
        //    //Arrange
        //    EmployeeService employeeService = new EmployeeService();
        //    TestDataGenerator testDataGenerator = new TestDataGenerator();

        //    var employeeList = testDataGenerator.GenerateEmployeeList();
        //    var employee = new Employee()
        //    {
        //        FirstName = "Екатерина",
        //        SureName = "Романова",
        //        PassportId = 851611,
        //        Date = new DateTime(2007, 04, 05),
        //        Salary = 6100
        //    };

        //    //Act
        //    //Assert
        //    Assert.Throws<AgeLimitException>(() => employeeService.AddEmployee(employee));
        //}

        //[Fact]
        //public void EmployeePassportExceptionsTest()
        //{
        //    //Arrange
        //    EmployeeService employeeService = new EmployeeService();
        //    TestDataGenerator testDataGenerator = new TestDataGenerator();

        //    var employeeList = testDataGenerator.GenerateEmployeeList();
        //    var employee = new Employee()
        //    {
        //        FirstName = "Екатерина",
        //        SureName = "Романова",
        //        PassportId = 0,
        //        Date = new DateTime(2002, 04, 05),
        //        Salary = 6100
        //    };

        //    //Act
        //    //Assert
        //    Assert.Throws<PassportIdException>(() => employeeService.AddEmployee(employee));
        //}

        [Fact]
        public void TestEmployeesAges()
        {
            var employeeStorage = new EmployeeStorage();
            var employeeService = new EmployeeService(employeeStorage);
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            List<Employee> employees = testDataGenerator.GenerateEmployeeList();

            foreach (Employee employee in employees)
            {
                employeeService.AddEmployee(employee);
            }

            var youngestEmployeeDate = employeeService.GetEmployees().Max(u => u.Date);
            var youngestEmployee = employeeService.Equals(youngestEmployeeDate);

            var oldestEmployeeDate = employeeService.GetEmployees().Min(u => u.Date);
            var oldestEmployee = employeeService.Equals(oldestEmployeeDate);

            Assert.Equal(oldestEmployee, youngestEmployee);
        }

        [Fact]
        public void TestEmployeesAvarageAge()
        {
            var employeeStorage = new EmployeeStorage();
            var employeeService = new EmployeeService(employeeStorage);
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            List<Employee> employees = testDataGenerator.GenerateEmployeeList();

            foreach (Employee employee in employees)
            {
                employeeService.AddEmployee(employee);
            }

            var avarageEmployeesAge = (int)employeeService.GetEmployees().Average(u => DateTime.Today.Year - u.Date.Year);

            Assert.True(avarageEmployeesAge > 0);
        }
    }
}
