using App.Data.Entities;
using App.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IOrderDbService : IBaseDbService<Order, OrderDTO>
    {
        Task<List<DisplayOrderDTO>> DisplayOrderList();
        DisplayOrderDTO FindDisplayOrderById(string id);
        Task AddOrderAsync(OrderDTO dto);
        Task<List<EmployeeDTO>> GetEmployees();
    }
}
