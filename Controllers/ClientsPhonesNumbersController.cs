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
    public class ClientsPhonesNumbersController : Controller
    {
        private IClientsPhonesNumbersRepository clientsPhonesNumbersRepository;

        public ClientsPhonesNumbersController(IClientsPhonesNumbersRepository clientsPhonesNumbersRepo)
        {
            clientsPhonesNumbersRepository = clientsPhonesNumbersRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await clientsPhonesNumbersRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new ClientPhoneNumber());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientPhoneNumber clientPhoneNumber)
        {
            await clientsPhonesNumbersRepository.Create(clientPhoneNumber);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientPhoneNumber clientPhoneNumber)
        {
            await clientsPhonesNumbersRepository.Update(clientPhoneNumber);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await clientsPhonesNumbersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientPhoneNumber clientPhoneNumber)
        {
            await clientsPhonesNumbersRepository.Delete(clientPhoneNumber);
            return RedirectToAction("Index");
        }
    }
}