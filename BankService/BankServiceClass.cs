using Models;

namespace BankService
{
    public class BankServiceClass
    {
        public double CountOwnerSalary(double profit, double expences, int amount)
        {
            return (profit - expences)/amount;
        }

        public Employee Convert(Client client)
        {
            Person person = client;
            Employee employee = person as Employee;
            return employee;
        }
    }
}
