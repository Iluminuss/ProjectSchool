using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class OrdersController:BaseController<Order, OrderDTO>
    {
        private readonly IOrderDbService _dbService;

        public OrdersController(IOrderDbService dbService):base(dbService)
        {
            _dbService = dbService;
        }

        public override IActionResult Index()
        {
            var displayOrders = _dbService.DisplayOrderList().Result;
            return View( displayOrders);
        }

        public override IActionResult Create()
        {
            ViewBag.Employees = _dbService.GetEmployees().Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(OrderDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _dbService.AddOrderAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public override async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dto = _dbService.FindDisplayOrderById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _dbService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
