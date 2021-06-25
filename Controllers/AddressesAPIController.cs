using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class AddressesAPIController:ControllerBase
    {
        private IAddressesRepository addressesRepository;

        public AddressesAPIController(IAddressesRepository addressesRepo)
        {
            addressesRepository = addressesRepo;
        }


    }
}
