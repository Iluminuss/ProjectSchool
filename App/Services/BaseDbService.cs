using AutoMapper;
using App.Data;
using App.Data.Entities;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services.Interfaces;

namespace App.Services
{
    public class BaseDbService<T, TG> : IBaseDbService<T, TG>
        where T : Base
        where TG : BaseDTO
    {
        private readonly ProjectDbContext DbContext;
        private readonly IMapper Mapper;

        public BaseDbService(ProjectDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<List<TG>> ToListAsync()
        {
            return Mapper.Map<List<TG>>(await DbContext.Set<T>().ToListAsync());
        }

        public async Task<TG> FindById(string id)
        {
            return Mapper.Map<TG>(await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task AddAsync(TG dto)
        {
            var entity = Mapper.Map<T>(dto);

            await DbContext.Set<T>().AddAsync(entity);

            await DbContext.SaveChangesAsync();

            dto.Id = entity.Id;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await DbContext.Set<T>().FirstAsync(x => x.Id == id);
            var deleted = DbContext.Set<T>().Remove(entity);
            if (deleted.State != EntityState.Deleted) return false;
            await DbContext.SaveChangesAsync();
            return true;
        }

        public bool Exists(string id)
        {
            return DbContext.Set<T>().Any(e => e.Id.ToString() == id);
        }

        public void Update(TG dto)
        {
            DbContext.Entry(Mapper.Map<T>(dto)).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
