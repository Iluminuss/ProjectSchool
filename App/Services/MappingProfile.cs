using AutoMapper;
using App.Data.Entities;
using App.Data.Models;

namespace App.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CookedFood, CookedFoodDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDTO>().ReverseMap();
        }
    }
}