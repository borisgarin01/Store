using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class CommonProductsLeftoversOnPrimaryWarehousesController : Controller
    {
        private ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepository;
        private IProductsRepository productsRepository;

        public CommonProductsLeftoversOnPrimaryWarehousesController(ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepo,
            IProductsRepository productsRepo)
        {
            commonProductsLeftoversOnPrimaryWarehouseRepository = commonProductsLeftoversOnPrimaryWarehouseRepo;
            productsRepository = productsRepo;
        }

        [Route("CommonProductsLeftoversOnPrimaryWarehouses")]
        public async Task<IActionResult> GetAllCommonProductsLeftoversOnPrimaryWarehouses()
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            return View(new CommonProductsLeftoversOnPrimaryWarehouse());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (ModelState.IsValid)
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Create(commonProductsLeftoversOnPrimaryWarehouse);
                return RedirectToAction("Index");
            }
            else return View(commonProductsLeftoversOnPrimaryWarehouse);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (ModelState.IsValid)
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Update(commonProductsLeftoversOnPrimaryWarehouse);
                return RedirectToAction("GetAllCommonProductsLeftoversOnPrimaryWarehouses");
            }
            else return View(commonProductsLeftoversOnPrimaryWarehouse);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            await commonProductsLeftoversOnPrimaryWarehouseRepository.Delete(commonProductsLeftoversOnPrimaryWarehouse);
            return RedirectToAction("GetAllCommonProductsLeftoversOnPrimaryWarehouses");
        }
    }
}
