using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class OrderDTO : BaseDTO
    {
        [Required] public string EmployeeId { get; set; }
        [Required][StringLength(256)] public string CustomerAddress{ get; set; }
        [Required][StringLength(32)] public string CustomerFirstName { get; set; }
        [Required][StringLength(32)] public string CustomerLastName { get; set; }
    }
}
