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
    public class ClientsController : Controller
    {
        private IClientsRepository clientsRepository;

        public ClientsController(IClientsRepository clientsRepo)
        {
            clientsRepository = clientsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await clientsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            await clientsRepository.Create(client);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Client client)
        {
            await clientsRepository.Update(client);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Client client)
        {
            await clientsRepository.Delete(client);
            return RedirectToAction("Index");
        }
    }
}