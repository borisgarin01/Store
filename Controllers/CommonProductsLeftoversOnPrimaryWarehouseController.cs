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
    public class CommonProductsLeftoversOnPrimaryWarehouseController : Controller
    {
        private ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepository;

        public CommonProductsLeftoversOnPrimaryWarehouseController(ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepo)
        {
            commonProductsLeftoversOnPrimaryWarehouseRepository = commonProductsLeftoversOnPrimaryWarehouseRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new CommonProductLeftoversOnPrimaryWarehouse());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            await commonProductsLeftoversOnPrimaryWarehouseRepository.Create(commonProductLeftoversOnPrimaryWarehouse);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            await commonProductsLeftoversOnPrimaryWarehouseRepository.Update(commonProductLeftoversOnPrimaryWarehouse);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            await commonProductsLeftoversOnPrimaryWarehouseRepository.Delete(commonProductLeftoversOnPrimaryWarehouse);
            return RedirectToAction("Index");
        }
    }
}