using App.Data.Entities;
using App.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IBaseDbService<T, TG>
        where T : Base
        where TG : BaseDTO
    {
        Task AddAsync(TG dto);
        bool Exists(string id);
        Task<TG> FindById(string? id);
        Task<bool> RemoveAsync(string id);
        Task<List<TG>> ToListAsync();
        void Update(TG dto);
    }
}