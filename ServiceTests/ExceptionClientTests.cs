using Xunit;
using Services.Exceptions;
using Services;
using Models;
using System;
using System.Collections.Generic;

namespace ServiceTests
{
    public class ExceptionClientTests
    {
        [Fact]
        public void TestWithClientAgeExceptions()
        {
            //Arrange
            ClientService clientService = new ClientService();
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            
            var clientsList = testDataGenerator.GenerateClientList();
            var client = new Client()
            {
                FirstName = "Виктор",
                SureName = "Антонов",
                PassportId = 851611,
                Date = new DateTime(2007, 05, 05),
                PhoneNumber = "77857454"
            };

            //Act 
            //Assert
            Assert.Throws<AgeLimitException>(() => clientService.AddingClientToList(clientsList, client));
        }

        [Fact]
        public void TestWithClientPassportExceptions()
        {
            //Arrange
            ClientService clientService = new ClientService();
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var clientsList = testDataGenerator.GenerateClientList();
            var client = new Client()
            {
                FirstName = "Виктор",
                SureName = "Антонов",
                PassportId = 0,
                Date = new DateTime(2004, 05, 05),
                PhoneNumber = "77857454"
            };

            //Act 
            //Assert
            Assert.Throws<PassportIdException>(() => clientService.AddingClientToList(clientsList, client));
        }

        [Fact]
        public void TestWithClientAccountExceptions()
        {
            //Arrange
            ClientService clientService = new ClientService();
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var clientAccountsList = testDataGenerator.GenerateClientAccounts();
            
            Account accountRUB = new Account() { Amount = 100000, Currency = new Currency { Name = "EUR", Code = 1111 } };

            var listAccount = new List<Account>();
            listAccount.Add(accountRUB);
            var client = new Client()
            {
                FirstName = "Mike",
                SureName = "Reiner",
                PassportId = 851611,
                Date = new DateTime(2003, 05, 05),
                PhoneNumber = "77957422"
            };
            
            //Act
            //Assert
            Assert.Throws<CurrencyException>(() => clientService.AddingClientToDictionary(clientAccountsList, listAccount, client));
        }
    }
}
