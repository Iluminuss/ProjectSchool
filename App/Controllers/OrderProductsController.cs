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
    public class OrderProductsController : BaseController<OrderProduct, OrderProductDTO>
    {
        private readonly IOrderProductDbService dbService;

        public OrderProductsController(IOrderProductDbService dbService):base(dbService)
        {
            this.dbService = dbService;
        }

        public override IActionResult Index()
        {
            ViewBag.Products = dbService.GetProducts().Result;
            ViewBag.Orders = dbService.GetOrders().Result;
            return View(dbService.ToListAsync().Result);
        }

        public override IActionResult Create()
        {
            ViewBag.Products = dbService.GetProducts().Result;
            ViewBag.Orders = dbService.GetOrders().Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([FromForm] OrderProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                await dbService.AddOrderProductAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
    }
}
