using System.Linq;
using Xunit;
using Models;
using Services;

namespace Sevices.Tests
{
    public class EquivalenceTests
    {
        [Fact]
        public void GetHashCodeNecessityPositivTest()
        {
            //Arrange
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            var clientsAccountDictionary = testDataGenerator.GenerateClientAccount();
            var oldClient = clientsAccountDictionary.Keys.FirstOrDefault();
            var newClient = new Client()
            {
                    FirstName = oldClient.FirstName,
                    SureName = oldClient.SureName,
                    PassportId = oldClient.PassportId,
                    Date = oldClient.Date,
                    PhoneNumber = oldClient.PhoneNumber
            };

            //Act
            var account = clientsAccountDictionary[newClient];

            //Assert
            Assert.Equal(oldClient, newClient);
        }

        [Fact]
        public void GetHashCodeNecessityPositivTest2()
        {
            //Arrange
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            var employeeList = testDataGenerator.GenerateEmployeeList();
            var oldEmployee = employeeList[1];
            var newEmployee = new Employee()
            {
                FirstName = oldEmployee.FirstName,
                SureName = oldEmployee.SureName,
                PassportId = oldEmployee.PassportId,
                Date = oldEmployee.Date,
                Salary = oldEmployee.Salary
            };

            //Act
            var employees = employeeList[1];

            //Assert
            Assert.Equal(oldEmployee, newEmployee);
        }
    }
}
