using System.Collections.Generic;

namespace App.Data.Models
{
    public class DisplayOrderDTO:OrderDTO
    {
        public DisplayOrderDTO(OrderDTO dto, string name, List<int> numbers)
        {
            this.Id = dto.Id;
            this.CustomerFirstName = dto.CustomerFirstName;
            this.CustomerAddress = dto.CustomerAddress;
            this.CustomerLastName = dto.CustomerLastName;
            this.EmployeeId = dto.EmployeeId;
            this.EmployeeName = name;
            this.OrderProductNumbers = numbers;
        }
        public string EmployeeName { get; set; }
        public List<int> OrderProductNumbers { get; set; }
    }
}
