using System;
using Models;
using System.Collections.Generic;
using System.Diagnostics;
using Services;
using System.Linq;

namespace PracticeWithListAndDictionary
{
    class Program
    {
        public Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var program = new Program();
            var clientsList = testDataGenerator.GenerateClientList();
            var clientsDictionary = testDataGenerator.GenerateClientDictionary();
            var employeesList = testDataGenerator.GenerateEmployeeList();

            Console.WriteLine("Клиенты младше 30ти лет:");
            program.ClientsAge(clientsList);

            
            
            program.ClientNumberFromList(clientsList);

            program.ClientNumberFromDictionary(clientsDictionary);

            program.MinimalSalary(employeesList);

            Console.ReadKey();
        }

        public void ClientNumberFromList(List<Client> clients)
        {
            var numberPhone = clients.First().PhoneNumber;
            sw.Start();
            var client = clients.FirstOrDefault(number => number.PhoneNumber == numberPhone);
            sw.Stop();
            Console.WriteLine($"Клиент с номером телефона {numberPhone}: {client.FirstName} {client.SureName} \n " +
                $"Найден в списке за {sw.ElapsedTicks} тиков");
        }

        public void ClientNumberFromDictionary(Dictionary<string, Client> clients)
        {
            var numberPhone = clients.First();
            sw.Start();
            var client = clients[numberPhone.Key];
            sw.Stop();
            Console.WriteLine($"Клиент с номером телефона {numberPhone.Value.PhoneNumber}: {client.FirstName} {client.SureName} \n " +
                $"Найден в словаре за {sw.ElapsedTicks} тиков");
        }

        public void ClientsAge(List<Client> clients)
        {
            var selectedPeople = clients.FindAll(client => DateTime.Today.Year - client.Date.Year < 30);
            foreach (var client in selectedPeople)
                Console.WriteLine($"Имя Фамилия: {client.FirstName} {client.SureName} Возраст: " + (DateTime.Today.Year - client.Date.Year));
        }

        public void MinimalSalary(List<Employee> employees)
        {
            var minSalary = employees.Min(employee => employee.Salary);
            var persons = employees.FindAll(employee => employee.Salary == minSalary);
            foreach (var person in persons)
                Console.WriteLine($"Минимальная зарплата: {person.Salary} у сотрудника {person.FirstName} {person.SureName}\n");
        }
    }
}
