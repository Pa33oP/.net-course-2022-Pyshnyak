using System;
using Models;
using System.Collections.Generic;
using System.Diagnostics;
using Services;
using System.Linq;

namespace PractiseWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.FirstName = "Николай";
            employee.SureName = "Николаев";

            WrongUpdateEmployeeContract(employee);
            Console.WriteLine(employee.Contract);

            employee.Contract = UpdateEmployeeContract(employee);
            Console.WriteLine(employee.Contract);

            Currency currency = new Currency();
            currency.Name = "Рубль ПМР";

            WrongUpdateCurrency(currency);
            Console.WriteLine("Рубль ПМР конвертируем в " + currency.Name);

            currency.Name = RightUpdateCurrency(currency);
            Console.WriteLine("Рубль ПМР конвертируем в " + currency.Name);


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

            //GetClientsAge(clientsList);

            //EmployeeDataList(employeesList);
            GetMinimumSalary(employeesList);

            Console.ReadKey();
        }

        static void WrongUpdateEmployeeContract(Employee employee)
        {
            employee.Contract = $"Новый контракт с { employee.FirstName } {employee.SureName} от 25.05.2022";
        }

        static string UpdateEmployeeContract(Employee employee)
        {
            return employee.Contract = $"Новый контракт с { employee.FirstName } {employee.SureName} от 25.05.2023";
        }

        static void WrongUpdateCurrency(Currency currency)
        {
            currency.Name = "Рубль РФ";
        }

        static string RightUpdateCurrency(Currency currency)
        {
            return currency.Name = "Рубль РФ";
        }

        static void GetClientNumberFromList(List<Client> clients)
        {
            foreach (var number in clients)
                if (number.PhoneNumber == 3)
                {
                    clients.FirstOrDefault(number => number.PhoneNumber == 3);
                    Console.WriteLine("Сотрудник с номером 3: " + number.FirstName);
                }
        }

        static void GetClientNumberFromDictionary(Dictionary<int, Client> clients)
        {
            clients.GetValueOrDefault(5);
        }

        //static void GetClientsAge(List<Client> clients)
        //{
        //    Console.WriteLine("Сотрудники родившиеся после 1 января 1995 года:");
        //    DateTime start = new DateTime(1995, 01, 01);
        //    var selectedPeople = from p in clients // передаем каждый элемент из people в переменную p
        //                         where p.Date.Year > 1995 //фильтрация по критерию
        //                         select p;
        //    foreach (var client in selectedPeople)
        //        Console.WriteLine(client.Date + client.FirstName);
        //    //var selectedPeople = clients.FindAll(client => client.Date.Year < 1995);
        //    //foreach (var client in selectedPeople)
        //    //    Console.WriteLine(client.Date + client.FirstName);
        //}

        static void GetMinimumSalary(List<Employee> employees)
        {
            var minSalary = employees.Min(employee => employee.Salary);
            var persons = employees.FindAll(employee => employee.Salary == minSalary);
            foreach (var person in persons)
                Console.WriteLine("Минимальная зарплата: " + person.Salary + " у сотрудника " + person.FirstName);
        }
    }
}
