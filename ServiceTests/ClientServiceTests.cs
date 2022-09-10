using Xunit;
using Services.Exceptions;
using Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTests
{
    public class ClientServiceTests
    {
        //[Fact]
        //public void ClientAgeExceptionsTest()
        //{
        //    //Arrange
        //    var clientService = new ClientService();
        //    var testDataGenerator = new TestDataGenerator();

        //    var clientAccountsList = testDataGenerator.GenerateClientAccounts();
        //    var client = new Client()
        //    {
        //        FirstName = "Mike",
        //        SureName = "Reiner",
        //        PassportId = 851611,
        //        Date = new DateTime(2008, 05, 05),
        //        PhoneNumber = "77957422"
        //    };

        //    //Act
        //    //Assert
        //    Assert.Throws<AgeLimitException>(() => clientService.AddClient(client));
        //}

        //[Fact]
        //public void ClientPassportExceptionsTest()
        //{
        //    //Arrange
        //    var clientService = new ClientService();
        //    var testDataGenerator = new TestDataGenerator();

        //    var clientAccountsList = testDataGenerator.GenerateClientAccounts();
        //    var client = new Client()
        //    {
        //        FirstName = "Mike",
        //        SureName = "Reiner",
        //        PassportId = 0,
        //        Date = new DateTime(2003, 05, 05),
        //        PhoneNumber = "77957422"
        //    };

        //    //Act
        //    //Assert
        //    Assert.Throws<PassportIdException>(() => clientService.AddClient(client));
        //}

        [Fact]
        public void TestClientAges()
        {
            var clientStorage = new ClientStorage();
            var clientService = new ClientService(clientStorage);
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            List<Client> clients = testDataGenerator.GenerateClientList();

            foreach (Client client in clients)
            {
                clientService.AddClient(client);
            }

            var youngestClientDate = clientService.GetClients().Max(u => u.Key.Date);
            var youngestClient = clientService.GetClients().Equals(youngestClientDate);

            var oldestClientDate = clientService.GetClients().Min(u => u.Key.Date);
            var oldestClient = clientService.Equals(oldestClientDate);

            Assert.Equal(oldestClient, youngestClient);
        }

        [Fact]
        public void TestClientsAvarageAge()
        {
            var clientStorage = new ClientStorage();
            var clientService = new ClientService(clientStorage);
            TestDataGenerator testDataGenerator = new TestDataGenerator();
            List<Client> clients = testDataGenerator.GenerateClientList();

            foreach (Client client in clients)
            {
                clientService.AddClient(client);
            }

            var avarageAgeClients = (int)clientService.GetClients().Average(u => DateTime.Today.Year - u.Key.Date.Year);

            Assert.True(avarageAgeClients > 0);
        }
    }
}
