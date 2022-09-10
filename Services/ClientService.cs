using System;
using System.Collections.Generic;
using Models;
using Services.Exceptions;
using System.Linq;

namespace Services
{
    public class ClientService
    {
        //private Dictionary<Client, List<Account>> _clients = new Dictionary<Client, List<Account>>();

        //public void AddClient(Client client)
        //{
        //    var listAccount = new List<Account>();
        //    var newAccount = new Account()
        //    {
        //        Amount = 100000,
        //        Currency = new Currency { Name = "USD", Code = 1111 }
        //    };

        //    listAccount.Add(newAccount);

        //    if (client.Date.Year > 2004)
        //        throw new AgeLimitException("Предполагаемому владельцу счёта нет 18 лет!");

        //    if (client.PassportId == 0)
        //        throw new PassportIdException("У предполагаемого владельца счёта нет паспорта!");

        //    _clients.Add(client, listAccount);
        //}

        private ClientStorage _clientStorage;

        public ClientService(ClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public void AddClient(Client client)
        {
            _clientStorage.Add(client);
        }

        public IEnumerable<KeyValuePair<Client,List<Account>>> GetClients()
        {
            var newClientList = from client in _clientStorage._clientsDictionary
                                where client.Key.Date.Year >= 1992 && client.Key.Date.Year <= 1995
                                select client;

            newClientList = from client in newClientList.ToList()
                            where client.Key.FirstName.Contains("А")
                            select client;

            newClientList = from client in newClientList
                            where client.Key.PhoneNumber.Contains("7")
                            select client;

            newClientList = from client in newClientList
                            where client.Key.PassportId.ToString().Contains("5")
                            select client;
            
            return newClientList;
        }
    }
}
