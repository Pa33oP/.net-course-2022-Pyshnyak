using Xunit;
using Services;
using Services.Exceptions;
using Models;
using System;

namespace ServiceTests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void EmployeeAgeExceptionsTest()
        {
            //Arrange
            EmployeeService employeeService = new EmployeeService();
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var employeeList = testDataGenerator.GenerateEmployeeList();
            var employee = new Employee()
            {
                FirstName = "Екатерина",
                SureName = "Романова",
                PassportId = 851611,
                Date = new DateTime(2007, 04, 05),
                Salary = 6100
            };

            //Act
            //Assert
            Assert.Throws<AgeLimitException>(() => employeeService.AddEmployee(employee));
        }

        [Fact]
        public void EmployeePassportExceptionsTest()
        {
            //Arrange
            EmployeeService employeeService = new EmployeeService();
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var employeeList = testDataGenerator.GenerateEmployeeList();
            var employee = new Employee()
            {
                FirstName = "Екатерина",
                SureName = "Романова",
                PassportId = 0,
                Date = new DateTime(2002, 04, 05),
                Salary = 6100
            };

            //Act
            //Assert
            Assert.Throws<PassportIdException>(() => employeeService.AddEmployee(employee));
        }
    }
}
