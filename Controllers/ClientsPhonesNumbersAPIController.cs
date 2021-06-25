using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsPhonesNumbersAPIController : ControllerBase
    {
        private IClientsPhonesNumbersRepository clientsPhonesNumbersRepository;

        public ClientsPhonesNumbersAPIController(IClientsPhonesNumbersRepository clientsPhonesNumbersRepo)
        {
            clientsPhonesNumbersRepository = clientsPhonesNumbersRepo;
        }
    }
}
