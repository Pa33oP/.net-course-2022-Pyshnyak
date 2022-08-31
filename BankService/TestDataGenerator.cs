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
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("########"));

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
    }
}
