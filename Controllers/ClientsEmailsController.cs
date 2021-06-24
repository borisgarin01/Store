using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ClientsEmailsController : Controller
    {
        private StoreContext storeContext;

        public ClientsEmailsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("ClientsEmails")]
        public async Task<IActionResult> GetAllClientsEmails()
        {
            return View(await storeContext.ClientsEmails.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await storeContext.Clients.ToListAsync();
            return View(new ClientsEmail());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsEmail clientsEmail)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsEmails.Add(clientsEmail);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(clientsEmail);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.ClientsEmails.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Clients = await storeContext.Clients.ToListAsync();
            return View(await storeContext.ClientsEmails.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsEmail clientsEmail)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsEmails.Update(clientsEmail);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsEmails");
            }
            else return View(clientsEmail);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.ClientsEmails.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsEmail clientsEmail)
        {
                storeContext.ClientsEmails.Remove(clientsEmail);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsEmails");
        }
    }
}
