using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _appContext;

        public ItemsController(MyAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _appContext.Items
                .Include(s => s.SerialNumber)
                .Include(c => c.Category)
                .Include(ic => ic.ItemClients)
                .ThenInclude(c => c.Client)
                .ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_appContext.Categories, "Id","Name");

            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Description, Type, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _appContext.Items.Add(item);
                await _appContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(item);
        }


        public async Task<IActionResult> Edit(int itemid)
        {
            ViewData["Categories"] = new SelectList(_appContext.Categories, "Id", "Name");

            var item = await _appContext.Items.FirstOrDefaultAsync(item => item.Id == itemid);

            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int itemid, [Bind("Id, Name, Description, Type, Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _appContext.Items.Update(item);
                await _appContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<IActionResult> Delete(int itemid)
        {
            var item = await _appContext.Items.FirstOrDefaultAsync(item => item.Id == itemid);

            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int itemid)
        {
            var item = await _appContext.Items.FindAsync(itemid);

            if(item != null)
            {
                _appContext.Items.Remove(item);
                await _appContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
