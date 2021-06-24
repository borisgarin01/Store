using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class CommonProductsLeftoversOnPrimaryWarehousesController : Controller
    {
        private StoreContext storeContext;

        public CommonProductsLeftoversOnPrimaryWarehousesController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("CommonProductsLeftoversOnPrimaryWarehouses")]
        public async Task<IActionResult> GetAllCommonProductsLeftoversOnPrimaryWarehouses()
        {
            return View(await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = new SelectList(await storeContext.Products.ToListAsync(), "Id", "ProductName");
            return View(new CommonProductsLeftoversOnPrimaryWarehouse());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (ModelState.IsValid)
            {
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Add(commonProductsLeftoversOnPrimaryWarehouse);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(commonProductsLeftoversOnPrimaryWarehouse);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Products = new SelectList(await storeContext.Products.ToListAsync(), "Id", "ProductName");
            return View(await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (ModelState.IsValid)
            {
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Update(commonProductsLeftoversOnPrimaryWarehouse);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCommonProductsLeftoversOnPrimaryWarehouses");
            }
            else return View(commonProductsLeftoversOnPrimaryWarehouse);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Remove(commonProductsLeftoversOnPrimaryWarehouse);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCommonProductsLeftoversOnPrimaryWarehouses");
        }
    }
}
