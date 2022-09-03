namespace Models
{
    public class Client : Person 
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Client))
                return false;
            var client = (Client)obj;

            return client.FirstName == FirstName &&
            client.SureName == SureName &&
            client.PhoneNumber == PhoneNumber &&
            client.PassportId == PassportId &&
            client.Date == Date;
        }

        public override int GetHashCode()
        {
            return PassportId.GetHashCode();
        }
    }
}
