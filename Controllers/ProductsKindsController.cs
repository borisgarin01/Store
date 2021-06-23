using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ProductsKindsController : Controller
    {
        private StoreContext storeContext;

        public ProductsKindsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("ProductsKinds")]
        public async Task<IActionResult> GetAllProductsKinds()
        {
            return View(await storeContext.ProductsKinds.ToListAsync());
        }
        
        public IActionResult Create()
        {
            return View(new ProductsKind());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsKind productsKind)
        {
            if (ModelState.IsValid)
            {
                storeContext.ProductsKinds.Add(productsKind);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(productsKind);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.ProductsKinds.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.ProductsKinds.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsKind productsKind)
        {
            if (ModelState.IsValid)
            {
                storeContext.ProductsKinds.Update(productsKind);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllProductsKinds");
            }
            else return View(productsKind);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.ProductsKinds.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductsKind productsKind)
        {
            List<Product> productsToDelete = storeContext.Products.Where(p=>p.ProductKindId==productsKind.Id).ToList();
            foreach(Product product in productsToDelete)
            {
                storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(ci => ci.ProductId == product.Id));
                storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(ci => ci.ProductId == product.Id));
                storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(ci => ci.ProductId == product.Id));
            }
            storeContext.Products.RemoveRange(productsToDelete);
            storeContext.ProductsKinds.Remove(productsKind);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllProductsKinds");
        }
    }
}
