using App.Data;
using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class OrderDbService : BaseDbService<Order, OrderDTO>, IOrderDbService
    {
        private readonly ProjectDbContext dbContext;
        private readonly IMapper mapper;

        public OrderDbService(ProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<DisplayOrderDTO>> DisplayOrderList()
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orderDTOs = mapper.Map<List<OrderDTO>>(await dbContext.Orders.Include(x => x.Employee).ToListAsync());
            List<DisplayOrderDTO> displayOrderDTOs = new List<DisplayOrderDTO>();
            orderDTOs.ForEach(dto =>
            {
                var displayOrderDTO = new DisplayOrderDTO(dto, GetEmployeeName(dto.EmployeeId), GetOrderProductNumbers(dto.Id));
                displayOrderDTOs.Add(displayOrderDTO);
            });
            return displayOrderDTOs;
        }

        public async Task AddOrderAsync(OrderDTO dto) {
            //dto.OrderProductNumbers = new List<int>();
            var order = mapper.Map<Order>(dto);
            dbContext.Orders.Add(order);
            dbContext.Entry(order.Employee).State = EntityState.Unchanged;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return mapper.Map<List<EmployeeDTO>>(await dbContext.Employees.ToListAsync());
        }

        public DisplayOrderDTO FindDisplayOrderById(string id)
        {
            return DisplayOrderList().Result.FirstOrDefault(x => x.Id == id);
        }

        private string GetEmployeeName(string id)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return employee.FirstName + " " + employee.LastName;
        }

        private List<int> GetOrderProductNumbers(string id)
        {
            var orderProducts = new List<int>(dbContext.OrderProducts.Where(x => x.Order.Id == id).Include(x => x.Order).Select(x => x.Number).ToList());
            return orderProducts;
        }

    }
}
