using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ClientsAddressesController : Controller
    {
        private IClientsAddressesRepository clientsAddressesRepository;
        private IAddressesRepository addressesRepository;
        private IClientsRepository clientsRepository;

        public ClientsAddressesController
            (IClientsAddressesRepository clientsAddressesRepo,
            IAddressesRepository addressesRepo,
            IClientsRepository clientsRepo)
        {
            clientsAddressesRepository = clientsAddressesRepo;
            addressesRepository = addressesRepo;
            clientsRepository = clientsRepo;
        }

        [Route("ClientsAddresses")]
        public async Task<IActionResult> GetAllClientsAddresses()
        {
            return View(await clientsAddressesRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Addresses = await addressesRepository.GetAll();
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(new ClientsAddress());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsAddress clientsAddress)
        {
            if (ModelState.IsValid)
            {
                await clientsAddressesRepository.Create(clientsAddress);
                return RedirectToAction("Index");
            }
            else return View(clientsAddress);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await clientsAddressesRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Addresses = await addressesRepository.GetAll();
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(await clientsAddressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsAddress clientsAddress)
        {
            if (ModelState.IsValid)
            {
                await clientsAddressesRepository.Update(clientsAddress);
                return RedirectToAction("GetAllClientsAddresses");
            }
            else return View(clientsAddress);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsAddressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsAddress clientsAddress)
        {
                await clientsAddressesRepository.Delete(clientsAddress);
                return RedirectToAction("GetAllClientsAddresses");
        }
    }
}
