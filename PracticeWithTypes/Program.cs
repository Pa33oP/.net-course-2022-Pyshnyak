using System;
using Models;

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
    }
}
