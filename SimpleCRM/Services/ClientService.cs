using SimpleCRM.Models;
using System.Collections.Generic;

namespace SimpleCRM.Services
{
    public class ClientService
    {
        private CRMDBContext _context;

        public ClientService()
        {
            _context = new CRMDBContext();
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void EditClient(int id, Client client)
        {
            var existclient = GetClient(id);
            if(existclient!=null)
            {
                existclient.Age = client.Age;
                existclient.City = client.City;
                existclient.FirstName = client.FirstName;
                existclient.Gender = client.Gender;
                existclient.LastName = client.LastName;
                _context.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            var existclient = GetClient(id);
            if(existclient!=null)
            {
                _context.Clients.Remove(existclient);
                _context.SaveChanges();
            }
        }

        public Client GetClient(int id)
        {
            return _context.Clients.Find(id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients;
        }
    }
}