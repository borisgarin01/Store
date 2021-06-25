using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class AddressesController:Controller
    {
        private IAddressesRepository addressesRepository;

        public AddressesController(IAddressesRepository addressesRepo)
        {
            addressesRepository = addressesRepo;
        }

        [Route("Addresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            return View(await addressesRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Address());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                await addressesRepository.Create(address);
                return RedirectToAction("GetAllAddresses");
            }
            else return View(address);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                await addressesRepository.Update(address);
                return RedirectToAction("GetAllAddresses");
            }
            else return View(address);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Address address)
        {
            await addressesRepository.Delete(address);
            return RedirectToAction("GetAllAddresses");
        }
    }
}
