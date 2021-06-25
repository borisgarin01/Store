using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ClientsEmailsController : Controller
    {
        private IClientsEmailsRepository clientsEmailsRepository;
        private IClientsRepository clientsRepository;

        public ClientsEmailsController(IClientsEmailsRepository clientsEmailsRepo,
            IClientsRepository clientsRepo)
        {
            clientsEmailsRepository = clientsEmailsRepo;
            clientsRepository = clientsRepo;
        }

        [Route("ClientsEmails")]
        public async Task<IActionResult> GetAllClientsEmails()
        {
            return View(await clientsEmailsRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(new ClientsEmail());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsEmail clientsEmail)
        {
            if (ModelState.IsValid)
            {
                await clientsEmailsRepository.Create(clientsEmail);
                return RedirectToAction("Index");
            }
            else return View(clientsEmail);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await clientsEmailsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(await clientsEmailsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsEmail clientsEmail)
        {
            if (ModelState.IsValid)
            {
                await clientsEmailsRepository.Update(clientsEmail);
                return RedirectToAction("GetAllClientsEmails");
            }
            else return View(clientsEmail);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsEmailsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsEmail clientsEmail)
        {
            await clientsEmailsRepository.Delete(clientsEmail);
            return RedirectToAction("GetAllClientsEmails");
        }
    }
}
