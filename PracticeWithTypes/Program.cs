using System;
using Models;

namespace PractiseWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //контракт
            Employee employee = new Employee();
            employee.Contract = "Контракт от 25.05.2021";
            Console.WriteLine(employee.Contract);

            WrongUpdateEmployeeContract(employee);
            Console.WriteLine(employee.Contract);

            employee.Contract = UpdateEmployeeContract(employee.Contract);
            Console.WriteLine(employee.Contract);

            //валюта
            Currency currency = new Currency();
            currency.Name = "Рубль ПМР";
            Console.WriteLine(currency.Name);

            WrongUpdateCurrency(currency);
            Console.WriteLine(currency.Name);

            currency.Name = RightUpdateCurrency(currency.Name);
            Console.WriteLine(currency.Name);

            Console.ReadKey();
        }

        static void WrongUpdateEmployeeContract(Employee employee)
        {
            employee.Contract = "Контракт от 25.05.2022";
        }

        static string UpdateEmployeeContract(string contract)
        {
            return "Контракт от 25.05.2022";
        }

        static void WrongUpdateCurrency(Currency currency)
        {
            currency.Name = "Рубль РФ";
        }

        static string RightUpdateCurrency(string currencyName)
        {
            return currencyName = "Рубль РФ";
        }
    }
}
