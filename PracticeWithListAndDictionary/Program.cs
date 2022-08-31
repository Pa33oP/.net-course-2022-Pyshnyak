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
        static void Main(string[] args)
        {
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            var clientsList = testDataGenerator.ClientsDataList();
            var clientsDictionary = testDataGenerator.ClientDataDictionary();
            var employeesList = testDataGenerator.EmployeeDataList();

            var sw = new Stopwatch();

            sw.Start();
            GetClientNumberFromList(clientsList);
            sw.Stop();
            Console.WriteLine("Время поиска струдника по номеру телефона в списке: " + sw.ElapsedTicks);
            sw.Reset();

            sw.Start();
            GetClientNumberFromDictionary(clientsDictionary);
            sw.Stop();
            Console.WriteLine("Время поиска струдника по номеру телефона в словаре: " + sw.ElapsedTicks);
            sw.Reset();

            GetClientsAge(clientsList);

            GetMinimumSalary(employeesList);

            Console.ReadKey();
        }

        static void GetClientNumberFromList(List<Client> clients)
        {
            var client = clients.FirstOrDefault(number => number.PhoneNumber == 777111);
            Console.WriteLine($"Клинт с номером телефона 777111: {client.FirstName} {client.SureName}");
        }

        static void GetClientNumberFromDictionary(Dictionary<int, Client> clients)
        {
            Console.WriteLine();
            var client = clients.FirstOrDefault(number => number.Key.Equals(777222));
            Console.WriteLine($"Клиент с номером телефона 777222: {client.Value.FirstName} {client.Value.SureName}");
        }

        static void GetClientsAge(List<Client> clients)
        {
            Console.WriteLine();
            Console.WriteLine("Клиенты младше 30ти лет:");
            var selectedPeople = clients.FindAll(client => DateTime.Today.Year - client.Date.Year < 30);
            foreach (var client in selectedPeople)
                Console.WriteLine($"Имя Фамилия: {client.FirstName} {client.SureName} Возраст: " + (DateTime.Today.Year - client.Date.Year));
        }

        static void GetMinimumSalary(List<Employee> employees)
        {
            Console.WriteLine();
            var minSalary = employees.Min(employee => employee.Salary);
            var persons = employees.FindAll(employee => employee.Salary == minSalary);
            foreach (var person in persons)
                Console.WriteLine($"Минимальная зарплата: {person.Salary} у сотрудника {person.FirstName} {person.SureName}");
        }
    }
}
