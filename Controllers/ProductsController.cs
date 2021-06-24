using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext storeContext;

        public ProductsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return View(await storeContext.Products.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await storeContext.Categories.ToListAsync(), "Id", "CategoryName");
            ViewBag.Manufacturers = new SelectList(await storeContext.Manufacturers.ToListAsync(), "Id", "ManufacturerName");
            ViewBag.ProductsKinds = new SelectList(await storeContext.ProductsKinds.ToListAsync(), "Id", "KindName");
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllProducts");
            }
            else return View(product);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Products.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Categories = new SelectList(await storeContext.Categories.ToListAsync(), "Id", "CategoryName");
            ViewBag.Manufacturers = new SelectList(await storeContext.Manufacturers.ToListAsync(), "Id", "ManufacturerName");
            ViewBag.ProductsKinds = new SelectList(await storeContext.ProductsKinds.ToListAsync(), "Id", "KindName");
            return View(await storeContext.Products.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                storeContext.Products.Update(product);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllProducts");
            }
            else return View(product);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Products.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
            storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(ci => ci.ProductId == product.Id));
            storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(ci => ci.ProductId == product.Id));
            storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(ci => ci.ProductId == product.Id));

            storeContext.Products.Remove(product);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllProducts");
        }
    }
}
