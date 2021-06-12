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
    public class LeftoversInStoresController : Controller
    {
        private ILeftoversInStoresRepository leftoversInStoresRepository;

        public LeftoversInStoresController(ILeftoversInStoresRepository leftoversInStoresRepo)
        {
            leftoversInStoresRepository = leftoversInStoresRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await leftoversInStoresRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new LeftoversInStore());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeftoversInStore leftoversInStore)
        {
            await leftoversInStoresRepository.Create(leftoversInStore);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await leftoversInStoresRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await leftoversInStoresRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(LeftoversInStore leftoversInStore)
        {
            await leftoversInStoresRepository.Update(leftoversInStore);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await leftoversInStoresRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LeftoversInStore leftoversInStore)
        {
            await leftoversInStoresRepository.Delete(leftoversInStore);
            return RedirectToAction("Index");
        }
    }
}