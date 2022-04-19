using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class OrderProductDbService:BaseDbService<OrderProduct, OrderProductDTO>, IOrderProductDbService
    {
        private readonly ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public OrderProductDbService(ProjectDbContext dbContext, IMapper mapper):base(dbContext, mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddOrderProductAsync(OrderProductDTO dto)
        {
            var entity = mapper.Map<OrderProduct>(dto);
            var product = dbContext.Products.Find(dto.ProductId);
            product.Quantity -= (int)dto.Quantity;
            var order = dbContext.Orders.Find(dto.OrderId);
            dbContext.Entry(product).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            dbContext.Entry(product).State = EntityState.Detached;
            dbContext.Entry(order).State = EntityState.Detached;
            dbContext.OrderProducts.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return mapper.Map<List<ProductDTO>>(await dbContext.Products.ToListAsync());
        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            return mapper.Map<List<OrderDTO>>(await dbContext.Orders.ToListAsync());
        }

        public Task<bool> RemoveOrderProductAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
