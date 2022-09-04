using System;

namespace Models
{
    public class Employee : Person 
    {
        public string Contract { get; set; }
        public int Salary { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Employee))
                return false;
            var employee = (Employee)obj;

            return employee.FirstName == FirstName &&
            employee.SureName == SureName &&
            employee.PassportId == PassportId &&
            employee.Date == Date &&
            employee.Salary == Salary;
        }


    }
}
