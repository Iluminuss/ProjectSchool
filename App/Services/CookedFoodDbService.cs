using App.Data;
using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class CookedFoodDbService : BaseDbService<CookedFood, CookedFoodDTO>, ICookedFoodDbService
    {
        private readonly ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public CookedFoodDbService(ProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task AddCookedFoodAsync(CookedFoodDTO dto)
        {
            var product = GetProduct(dto.ProductId);
            var cookedFood = mapper.Map<CookedFood>(dto);
            product.Quantity += dto.Quantity;
            dbContext.Entry(product).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            dbContext.Entry(product).State = EntityState.Detached;
            dbContext.CookedFoods.Attach(cookedFood);
            dbContext.Entry(cookedFood).State = EntityState.Added;  // or EntityState.Modified
            dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            dto.Id = cookedFood.Id;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return mapper.Map<List<ProductDTO>>(await dbContext.Products.ToListAsync());
        }

        public async Task<bool> RemoveCookedFoodAsync(string id)
        {
            var cookedFood = dbContext.CookedFoods.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id).Result;
            dbContext.Products.Find(cookedFood.Product.Id).Quantity -= cookedFood.Quantity;
            var deleted = dbContext.CookedFoods.Remove(cookedFood);
            if (deleted.State != EntityState.Deleted) return false;
            await dbContext.SaveChangesAsync();
            return true;
        }
        public void UpdateCookedFood(CookedFoodDTO dto)
        {
            int diff = dto.Quantity;
            var cookedFoodQuantity = dbContext.CookedFoods.Find(dto.Id).Quantity;
            diff -= cookedFoodQuantity;
            dbContext.Entry(mapper.Map<CookedFood>(dto)).State = EntityState.Modified;
            dbContext.Products.Find(dto.Id).Quantity += cookedFoodQuantity;
            dbContext.SaveChanges();
        }

        private Product GetProduct(string id)
        {
            return dbContext.Set<Product>().FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
