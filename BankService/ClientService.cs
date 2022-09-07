using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientService
    {
        private Dictionary<Client, List<Account>> clients = new Dictionary<Client, List<Account>>();
        
        public void AddClientToDictionary(Client client)
        {
            var listAccount = new List<Account>();
            var newAccount = new Account()
            { 
                Amount = 100000, 
                Currency = new Currency { Name = "USD", Code = 1111 } 
            };

            listAccount.Add(newAccount);

            if (client.Date.Year > 2004)
                throw new AgeLimitException("Предполагаемому владельцу счёта нет 18 лет!");

            if (client.PassportId == 0)
                throw new PassportIdException("У предполагаемого владельца счёта нет паспорта!");

            clients.Add(client, listAccount);
        }
    }
}
