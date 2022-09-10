using System;
using System.Collections.Generic;
using Models;
using Bogus;

namespace Services
{
    public class TestDataGenerator
    {
        private Faker<Client> fakeClients = new Faker<Client>("ru")
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.SureName, f => f.Person.LastName)
            .RuleFor(u => u.PassportId, f => f.Random.Int(111111, 999999))
            .RuleFor(u => u.Date, f => f.Date.Between(new DateTime(1990, 01, 01),new DateTime(1999, 01, 01)))
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("##"));

        private Faker<Employee> fakeEmployees = new Faker<Employee>("ru")
            .RuleFor(e => e.FirstName, f => f.Person.FirstName)
            .RuleFor(e => e.SureName, f => f.Person.LastName)
            .RuleFor(e => e.PassportId, f => f.Random.Int(111111, 999999))
            .RuleFor(e => e.Date, f => f.Date.Between(new DateTime(1990, 01, 01), new DateTime(1999, 01, 01)))
            .RuleFor(e => e.Salary, f => f.Random.Int(5000, 7000));

        public List<Client> GenerateClientList()
        {
            return fakeClients.Generate(1000);
        }

        public Dictionary<string, Client> GenerateClientDictionary()
        {
            var clientDictionary = new Dictionary<string, Client>();
            for (int i = 0; i < 1000; i++)
            {
                var client = fakeClients.Generate();
                clientDictionary.Add(client.PhoneNumber, client);
            }

            return clientDictionary;
        }

        public List<Employee> GenerateEmployeeList()
        {
            return fakeEmployees.Generate(1000);
        }

        //Создание словаря "Клиент - счёт"
        public Dictionary<Client, Account> GenerateClientAccount()
        {
            var clientAccountDictionary = new Dictionary<Client, Account>();
            var currency = new Currency() { Name = "USD", Code = 446672 };
            Random random = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                var client = fakeClients.Generate();
                clientAccountDictionary.Add(client, new Account
                {
                    Amount = random.Next(100000,500000),
                    Currency = currency
                });
            }

            return clientAccountDictionary;
        }

        //Создание словаря "Клиент - список счетов"
        public Dictionary<Client, List<Account>> GenerateClientAccounts()
        {
            var clientAccountsDictionary = new Dictionary<Client, List<Account>>();
            string[] currencyNames = { "USD", "RUB", "MDL" };

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                var listAccount = new List<Account>();
                var client = fakeClients.Generate();
                for (int j = 0; j < random.Next(1, 3); j++)
                {
                    
                    var account = new Account() 
                    { 
                        Amount = random.Next(100000,500000),
                        Currency = new Currency 
                        { 
                            Name = currencyNames[random.Next(0, currencyNames.Length)], 
                            Code = random.Next(1111,1113)
                        } 
                    };
                    listAccount.Add(account);
                }
                clientAccountsDictionary.Add(client, listAccount);
            }

            return clientAccountsDictionary;
        }
    }
}
