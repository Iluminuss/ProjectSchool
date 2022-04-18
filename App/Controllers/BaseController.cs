using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class BaseController<T, TG> : Controller
        where T : Base
        where TG : BaseDTO
    {
        private readonly IBaseDbService<T, TG> dbService;

        protected BaseController(IBaseDbService<T, TG> DbService)
        {
            dbService = DbService;
        }
        public virtual IActionResult Index()
        {
            var dtos = dbService.ToListAsync().Result;
            return View(dtos);
        }

        public virtual async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dto = await dbService.FindById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TG dto)
        {
            if (ModelState.IsValid)
            {
                await dbService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public virtual async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dto = await dbService.FindById(id);
            if (dto == null)
            {
                return NotFound();
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(string id, TG dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbService.Update(dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbService.Exists(dto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public virtual async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dto = await dbService.FindById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(string id)
        {
            await dbService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
