using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;

namespace App.Controllers
{
    public class CookedFoodsController : BaseController<CookedFood, CookedFoodDTO>
    {
        private readonly ICookedFoodDbService dbService;

        public CookedFoodsController(ICookedFoodDbService dbService):base(dbService)
        {
            this.dbService = dbService;
        }

        // GET: CookedFoods
        public override IActionResult Index()
        {
            ViewBag.Products = dbService.GetProducts().Result;
            var dtos = dbService.ToListAsync().Result;
            return View(dtos);
        }

        // GET: CookedFoods/Create
        public override IActionResult Create()
        {
            ViewBag.Products = dbService.GetProducts().Result;
            return View();
        }

        // POST: CookedFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(CookedFoodDTO cookedFood)
        {
            if (ModelState.IsValid)
            {
                await dbService.AddCookedFoodAsync(cookedFood);
                return RedirectToAction(nameof(Index));
            }
            return View(cookedFood);
        }

        // POST: CookedFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(string id, CookedFoodDTO cookedFood)
        {
            if (id != cookedFood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbService.UpdateCookedFood(cookedFood);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookedFoodExists(cookedFood.Id))
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
            return View(cookedFood);
        }

        // POST: CookedFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cookedFood = await dbService.FindById(id);
            await dbService.RemoveCookedFoodAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CookedFoodExists(string id)
        {
            return dbService.Exists(id);
        }
    }
}
