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

            program.ClientNumberFromDictionaryWithKey(clientsDictionary);
            
            program.ClientNumberFromDictionaryWithFirstOrDefault(clientsDictionary);

            program.MinimalSalary(employeesList);

            Console.ReadKey();
        }

        public void ClientNumberFromList(List<Client> clients)
        {
            var numberPhone = clients.First().PhoneNumber;
            sw.Start();
            var client = clients.FirstOrDefault(number => number.PhoneNumber == numberPhone);
            sw.Stop();
            Console.WriteLine($"Клиент с номером телефона {numberPhone}: {client.FirstName} {client.SureName} найден в списке.\n" +
                $"Время: {sw.ElapsedTicks}");
        }

        public void ClientNumberFromDictionaryWithKey(Dictionary<string, Client> clients)
        {
            var numberPhone = clients.Last();
            sw.Start();
            var client = clients[numberPhone.Key];
            sw.Stop();
            Console.WriteLine($"Клиент с номером телефона {numberPhone.Value.PhoneNumber}: {client.FirstName} {client.SureName} найден в словаре по ключу.\n" +
                $"Время: {sw.ElapsedTicks}");
        }

        public void ClientNumberFromDictionaryWithFirstOrDefault(Dictionary<string, Client> clients)
        {
            var numberPhone = clients.Last().Key;
            sw.Start();
            var client = clients.FirstOrDefault(number => number.Key.Equals(numberPhone));
            sw.Stop();
            Console.WriteLine($"Клиент с номером телефона {client.Key}: {client.Value.FirstName} {client.Value.SureName} найден в словаре" +
                $"при помощи FirstOrDefault. Время: {sw.ElapsedTicks}");
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
