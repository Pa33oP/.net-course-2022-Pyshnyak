using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class TestDataGenerator
    {
        public List<Client> ClientsDataList()
        {
            var clients = new List<Client>();
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int year = rand.Next(1990, 1999);
                clients.Add(new Client
                {
                    FirstName = "Name_" + i,
                    SureName = "Surename_" + i,
                    PassportId = i + 1234,
                    Date = new DateTime(year, 01, 01),
                    PhoneNumber = i + 1
                });
            }

            return clients;
        }

        public Dictionary<int, Client> ClientDataDictionary()
        {
            var clients = new Dictionary<int, Client>();
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int year = rand.Next(1990, 1999);
                Client client = new Client();
                clients.Add(i, new Client
                {
                    FirstName = "Name_" + i,
                    SureName = "Surename_" + i,
                    PassportId = i + 1234,
                    Date = new DateTime(year, 01, 01),
                    PhoneNumber = i + 1
                });
            }
            return clients;
        }

        public List<Employee> EmployeeDataList()
        {
            var employees = new List<Employee>();
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int salary = rand.Next(5000, 7000);
                int year = rand.Next(1990, 1999);
                employees.Add(new Employee
                {
                    FirstName = "Name_" + i,
                    SureName = "Surename_" + i,
                    PassportId = i + 1234,
                    Date = new DateTime(year, 01, 01),
                    Salary = salary
                });
            }
            return employees;
        }
    }
}
