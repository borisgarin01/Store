using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsAPIController : ControllerBase
    {
        private IClientsRepository clientsRepository;

        public ClientsAPIController(IClientsRepository clientsRepo)
        {
            clientsRepository = clientsRepo;
        }
    }
}
