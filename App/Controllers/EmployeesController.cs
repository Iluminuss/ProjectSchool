using App.Data.Entities;
using App.Data.Models;
using App.Services.Interfaces;

namespace App.Controllers
{
    public class EmployeesController : BaseController<Employee, EmployeeDTO>
    {
        private readonly IBaseDbService<Employee, EmployeeDTO> _dbService;

        public EmployeesController(IBaseDbService<Employee, EmployeeDTO> dbService):base(dbService)
        {
            _dbService = dbService;
        }
    }
}
