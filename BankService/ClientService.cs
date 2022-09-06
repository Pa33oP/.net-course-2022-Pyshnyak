using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientService
    {
        public List<Client> AddingClientToList(List<Client> clients, Client client)
        {
            if (client.Date.Year > 2004)
                throw new AgeLimitException("Данному клиенту нет 18ти лет!");

            if (client.PassportId == 0)
                throw new PassportIdException("У клиента нет паспорта!");

            clients.Add(client);

            return clients;
        }

        public Dictionary<Client, List<Account>> AddingClientToDictionary(Dictionary<Client, List<Account>> clientAccountsDictionary, List<Account> accounts, Client client)
        {
            if (client.Date.Year > 2006)
                throw new AgeLimitException("Предполагаемому владельцу счёта нет 16 лет!");

            if (client.PassportId == 0)
                throw new PassportIdException("У предполагаемого владельца счёта нет паспорта!");

            foreach (var account in accounts)
                if (account.Currency.Name != "USD" && account.Currency.Name != "RUB" && account.Currency.Name != "MDL")
                    throw new CurrencyException("Банк не предоставляет услуг с данной валютой!");

            clientAccountsDictionary.Add(client, accounts);

            return clientAccountsDictionary;
        }
    }
}
