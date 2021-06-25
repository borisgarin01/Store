using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ClientsPhonesNumbersController : Controller
    {
        private IClientsPhonesNumbersRepository clientsPhonesNumbersRepository;
        private IClientsRepository clientsRepository;

        public ClientsPhonesNumbersController(IClientsPhonesNumbersRepository clientsPhonesNumbersRepo,
            IClientsRepository clientsRepo)
        {
            clientsPhonesNumbersRepository = clientsPhonesNumbersRepo;
            clientsRepository = clientsRepo;
        }

        [Route("ClientsPhonesNumbers")]
        public async Task<IActionResult> GetAllClientsPhonesNumbers()
        {
            return View(await clientsPhonesNumbersRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(new ClientsPhonesNumber());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (ModelState.IsValid)
            {
                await clientsPhonesNumbersRepository.Create(clientsPhonesNumber);
                return RedirectToAction("Index");
            }
            else return View(clientsPhonesNumber);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (ModelState.IsValid)
            {
                await clientsPhonesNumbersRepository.Update(clientsPhonesNumber);
                return RedirectToAction("GetAllClientsPhonesNumbers");
            }
            else return View(clientsPhonesNumber);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsPhonesNumber clientsPhonesNumber)
        {
            await clientsPhonesNumbersRepository.Delete(clientsPhonesNumber);
            return RedirectToAction("GetAllClientsPhonesNumbers");
        }
    }
}
