using Models;

namespace Services
{
    public class BankService
    {
        public int CountOwnerSalary(double profit, double expences, int amount)
        {
            return (int)(profit - expences)/amount;
        }

        public Employee Convert(Client client)
        {
            var employee = new Employee
            {
                FirstName = client.FirstName,
                SureName = client.SureName,
                PassportId = client.PassportId,
                Date = client.Date
            };
            return employee;
        }
    }
}
