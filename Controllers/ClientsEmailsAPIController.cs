using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsEmailsAPIController : ControllerBase
    {
        private IClientsEmailsRepository clientsEmailsRepository;

        public ClientsEmailsAPIController(IClientsEmailsRepository clientsEmailsRepo)
        {
            clientsEmailsRepository = clientsEmailsRepo;
        }
    }
}
