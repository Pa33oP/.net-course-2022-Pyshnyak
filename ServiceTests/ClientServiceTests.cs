using Xunit;
using Services.Exceptions;
using Services;
using Models;
using System;
using System.Collections.Generic;

namespace ServiceTests
{
    public class ClientServiceTests
    {
        [Fact]
        public void TestWithClientAccountAgeExceptions()
        {
            //Arrange
            var clientService = new ClientService();
            var testDataGenerator = new TestDataGenerator();

            var clientAccountsList = testDataGenerator.GenerateClientAccounts();
            var client = new Client()
            {
                FirstName = "Mike",
                SureName = "Reiner",
                PassportId = 851611,
                Date = new DateTime(2008, 05, 05),
                PhoneNumber = "77957422"
            };
            
            //Act
            //Assert
            Assert.Throws<AgeLimitException>(() => clientService.AddClientToDictionary(client));
        }

        [Fact]
        public void TestWithClientAccountPassportExceptions()
        {
            //Arrange
            var clientService = new ClientService();
            var testDataGenerator = new TestDataGenerator();

            var clientAccountsList = testDataGenerator.GenerateClientAccounts();
            var client = new Client()
            {
                FirstName = "Mike",
                SureName = "Reiner",
                PassportId = 0,
                Date = new DateTime(2003, 05, 05),
                PhoneNumber = "77957422"
            };

            //Act
            //Assert
            Assert.Throws<PassportIdException>(() => clientService.AddClientToDictionary(client));
        }
    }
}
