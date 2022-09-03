using System;
using Services;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace PracticeWithEqualsAndGetHash
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDataGenerator testDataGenerator = new TestDataGenerator();

            //Поиск счёта по клиенту
            var clientsAccountDictionary = testDataGenerator.GenerateClientAccount();
            var oldClient = clientsAccountDictionary.Keys.FirstOrDefault();
            var newClient = new Client()
            {
                FirstName = oldClient.FirstName,
                SureName = oldClient.SureName,
                PassportId = oldClient.PassportId,
                Date = oldClient.Date,
                PhoneNumber = oldClient.PhoneNumber
            };
            var account = clientsAccountDictionary[newClient];

            //Поиск счетов по клиенту
            var clientsWithAccounts = testDataGenerator.GenerateClientAccounts();
            var oldClient2 = clientsWithAccounts.Keys.Last();
            var newClient2 = new Client()
            {
                FirstName = oldClient2.FirstName,
                SureName = oldClient2.SureName,
                PassportId = oldClient2.PassportId,
                Date = oldClient2.Date,
                PhoneNumber = oldClient2.PhoneNumber
            };
            var accounts = clientsWithAccounts[newClient2];

            //Поиск нового работника среди старых
            var employeeList = testDataGenerator.GenerateEmployeeList();
            var oldEmployee = employeeList[1];
            var newEmployee = new Employee()
            {
                FirstName = oldEmployee.FirstName,
                SureName = oldEmployee.SureName,
                PassportId = oldEmployee.PassportId,
                Date = oldEmployee.Date,
                Salary = oldEmployee.Salary
            };
            var employees = employeeList[1];
            
            Console.ReadKey();
        }
    }
}
