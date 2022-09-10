using System.Collections.Generic;
using Models;

namespace Services
{
    public class ClientStorage
    {
        public readonly Dictionary<Client, List<Account>> _clientsDictionary = new Dictionary<Client, List<Account>>();
        public void Add(Client client)
        {
            var listAccount = new List<Account>();
            var newAccount = new Account()
            {
                Amount = 100000,
                Currency = new Currency { Name = "USD", Code = 1111 }
            };

            listAccount.Add(newAccount);

            _clientsDictionary.Add(client, listAccount);
        }
    }
}
