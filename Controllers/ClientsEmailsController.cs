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
    public class ClientsEmailsController : Controller
    {
        private IClientsEmailsRepository clientsEmailsRepository;

        public ClientsEmailsController(IClientsEmailsRepository clientsEmailsRepo)
        {
            clientsEmailsRepository = clientsEmailsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await clientsEmailsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new ClientEmail());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientEmail clientEmail)
        {
            await clientsEmailsRepository.Create(clientEmail);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await clientsEmailsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await clientsEmailsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientEmail clientEmail)
        {
            await clientsEmailsRepository.Update(clientEmail);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsEmailsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientEmail clientEmail)
        {
            await clientsEmailsRepository.Delete(clientEmail);
            return RedirectToAction("Index");
        }
    }
}