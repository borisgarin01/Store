using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsAddressesAPIController : ControllerBase
    {
        private IClientsAddressesRepository clientsAddressesRepository;

        public ClientsAddressesAPIController(IClientsAddressesRepository clientsAddressesRepo)
        {
            clientsAddressesRepository = clientsAddressesRepo;
        }
    }
}
