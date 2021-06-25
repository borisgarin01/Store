using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ClientsController : Controller
    {
        private IClientsRepository clientsRepository;

        public ClientsController(IClientsRepository clientsRepo)
        {
            clientsRepository = clientsRepo;
        }

        [Route("Clients")]
        public async Task<IActionResult> GetAllClients()
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
            if (ModelState.IsValid)
            {
                await clientsRepository.Create(client);
                return RedirectToAction("Index");
            }
            else return View(client);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                await clientsRepository.Update(client);
                return RedirectToAction("GetAllClients");
            }
            else return View(client);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Client client)
        {
            await clientsRepository.Delete(client);
            return RedirectToAction("GetAllClients");
        }
    }
}
