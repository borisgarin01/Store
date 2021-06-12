using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    public class AddressesController : Controller
    {
        private IAddressesRepository addressesRepository;

        public AddressesController(IAddressesRepository addressesRepo)
        {
            addressesRepository = addressesRepo;
        }

        public async Task<IActionResult> Index()
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
            await addressesRepository.Create(address);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Address address)
        {
            await addressesRepository.Update(address);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await addressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Address address)
        {
            await addressesRepository.Delete(address);
            return RedirectToAction("Index");
        }
    }
}