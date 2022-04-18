using App.Data.Entities;
using App.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface ICookedFoodDbService:IBaseDbService<CookedFood, CookedFoodDTO>
    {
        Task AddCookedFoodAsync(CookedFoodDTO dto);
        Task<bool> RemoveCookedFoodAsync(string id);
        void UpdateCookedFood(CookedFoodDTO dto);

        Task<List<ProductDTO>> GetProducts();
    }
}