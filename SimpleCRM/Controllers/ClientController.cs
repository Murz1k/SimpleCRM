using SimpleCRM.Models;
using SimpleCRM.Services;
using System;
using System.Web.Mvc;

namespace SimpleCRM.Controllers
{
    public class ClientController : Controller
    {
        private ClientService _service;
        public ClientController()
        {
            _service = new ClientService();
        }

        public JsonResult GetAllClients()
        {
            return Json(_service.GetAllClients());
        }

        public void AddClient(Client client)
        {
            _service.AddClient(client);
        }

        public void EditClient(int id, Client client)
        {
            _service.EditClient(id, client);
        }

        public void DeleteClient(int id)
        {
            _service.DeleteClient(id);
        }

        public Client GetClient(int id)
        {
            return _service.GetClient(id);
        }

        public string GetGender(int id)
        {
            return ((Gender)id).ToString();
        }

        public JsonResult GetAllGenders()
        {
            return Json(Enum.GetValues(typeof(Gender)));
        }
    }
}
