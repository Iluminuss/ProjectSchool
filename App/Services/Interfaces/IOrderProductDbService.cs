using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Models;

namespace App.Services.Interfaces
{
    public interface IOrderProductDbService:IBaseDbService<OrderProduct, OrderProductDTO>
    {
        Task AddOrderProductAsync(OrderProductDTO dto);
        Task<bool> RemoveOrderProductAsync(string id);
        Task<List<ProductDTO>> GetProducts();
        Task<List<OrderDTO>> GetOrders();

    }
}
