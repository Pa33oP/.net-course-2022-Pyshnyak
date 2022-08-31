using System;
using System.Collections.Generic;
using Models;
using Bogus;

namespace Services
{
    public class TestDataGenerator
    {
        public List<Client> ClientsDataList()
        {
            var clients = new List<Client>();

            DateTime dateStart = new DateTime(1990, 01, 01);
            DateTime dateEnd = new DateTime(1999, 01, 01);

            var faker = new Faker<Client>()
            .RuleFor(u => u.FirstName, u => u.Person.FirstName)
            .RuleFor(u => u.SureName, u => u.Person.LastName)
            .RuleFor(u => u.PassportId, u => u.Random.Int(111111, 999999))
            .RuleFor(u => u.Date, u => u.Date.Between(dateStart, dateEnd));

            for (int i = 0; i < 1000; i++)
            {
                Client client = new Client();
                client.FirstName = faker.Generate().FirstName;
                client.SureName = faker.Generate().SureName;
                client.PassportId = faker.Generate().PassportId;
                client.Date = faker.Generate().Date;
                client.PhoneNumber = 777110 + i;
                clients.Add(client);
            }

            return clients;
        }

        public Dictionary<int, Client> ClientDataDictionary()
        {
            var clientsDictionary = new Dictionary<int, Client>();

            DateTime dateStart = new DateTime(1990, 01, 01);
            DateTime dateEnd = new DateTime(1999, 01, 01);

            var faker = new Faker<Client>()
            .RuleFor(c => c.FirstName, c => c.Person.FirstName)
            .RuleFor(c => c.SureName, c => c.Person.LastName)
            .RuleFor(c => c.PassportId, c => c.Random.Int(111111, 999999))
            .RuleFor(c => c.Date, c => c.Date.Between(dateStart, dateEnd))
            .RuleFor(c => c.PhoneNumber, c => c.Random.Int(777111, 778000));

            for (int i =0; i<1000; i++)
            {
                Client client = new Client();
                client.FirstName = faker.Generate().FirstName;
                client.SureName = faker.Generate().SureName;
                client.PassportId = faker.Generate().PassportId;
                client.Date = faker.Generate().Date;
                client.PhoneNumber = 777110 + i;
                clientsDictionary.Add(client.PhoneNumber,client);
            }
            return clientsDictionary;
        }

        public List<Employee> EmployeeDataList()
        {
            var employees = new List<Employee>();
            
            DateTime dateStart = new DateTime(1990, 01, 01);
            DateTime dateEnd = new DateTime(1999, 01, 01);

            var faker = new Faker<Employee>()
            .RuleFor(e => e.FirstName, e => e.Person.FirstName)
            .RuleFor(e => e.SureName, e => e.Person.LastName)
            .RuleFor(e => e.PassportId, e => e.Random.Int(111111, 999999))
            .RuleFor(e => e.Date, e => e.Date.Between(dateStart, dateEnd))
            .RuleFor(e => e.Salary, e => e.Random.Int(5000, 7000));

            for (int i = 0; i < 1000; i++)
            {
                Employee employee = new Employee();
                employee.FirstName = faker.Generate().FirstName;
                employee.SureName = faker.Generate().SureName;
                employee.PassportId = faker.Generate().PassportId;
                employee.Date = faker.Generate().Date;
                employee.Salary = faker.Generate().Salary;
                employees.Add(employee);
            }

            return employees;
        }
    }
}
