using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    public class ClientsAddressesController : Controller
    {
        private IClientsAddressesRepository clientsAddressesRepository;

        public ClientsAddressesController(IClientsAddressesRepository clientsAddressesRepo)
        {
            clientsAddressesRepository = clientsAddressesRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await clientsAddressesRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new ClientAddress());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientAddress clientAddress)
        {
            await clientsAddressesRepository.Create(clientAddress);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await clientsAddressesRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await clientsAddressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientAddress clientAddress)
        {
            await clientsAddressesRepository.Update(clientAddress);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsAddressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientAddress clientAddress)
        {
            await clientsAddressesRepository.Delete(clientAddress);
            return RedirectToAction("Index");
        }
    }
}