using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class LeftoversInStoresAPIController : ControllerBase
    {
        private ILeftoversInStoresRepository leftoversInStoresRepository;

        public LeftoversInStoresAPIController(ILeftoversInStoresRepository leftoversInStoresRepo)
        {
            leftoversInStoresRepository = leftoversInStoresRepo;
        }
    }
}
