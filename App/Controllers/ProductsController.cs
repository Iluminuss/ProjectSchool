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
using AutoMapper;
using App.Services.Interfaces;

namespace App.Controllers
{
    public class ProductsController : BaseController<Product, ProductDTO>
    {
        private readonly IBaseDbService<Product, ProductDTO> dbService;

        public ProductsController(IBaseDbService<Product, ProductDTO> dbService):base(dbService)
        {
            this.dbService = dbService;
        }
    }
}
